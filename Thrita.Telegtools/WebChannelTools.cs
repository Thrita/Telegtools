using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public class WebChannelTools : ChannelToolsBase, IChannelTools
    {
        public override TelegramPost GetPost(string channelName, int postId)
        {
            var telegramPost = Parse(GetPostHtml(channelName, postId));

            if (telegramPost != null)
            {
                telegramPost.ChannelName = channelName?.ToLower();
                telegramPost.ReadDate = DateTime.Now;
            }

            return telegramPost;
        }

        public override async Task<TelegramPost> GetPostAsync(string channelName, int postId)
        {
            var telegramPost = Parse(await GetPostHtmlAsync(channelName, postId));

            if (telegramPost != null)
            {
                telegramPost.ChannelName = channelName?.ToLower();
                telegramPost.ReadDate = DateTime.Now;
            }

            return telegramPost;
        }

        public TelegramPost Parse(string rawHtml)
        {
            if (rawHtml == null)
                throw new ArgumentNullException(nameof(rawHtml));

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(rawHtml);
            return Parse(htmlDocument);
        }

        protected HtmlDocument GetPostHtml(string channelName, int postId)
        {
            if (string.IsNullOrWhiteSpace(channelName))
                throw new ArgumentException(nameof(channelName));
            if (postId < 1)
                throw new ArgumentException(nameof(postId));

            var url = $"https://t.me/{channelName}/{postId}?embed=1";

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException(nameof(channelName));
            }

            return new HtmlWeb().Load(uri);
        }

        protected async Task<HtmlDocument> GetPostHtmlAsync(string channelName, int postId)
        {
            if (string.IsNullOrWhiteSpace(channelName))
                throw new ArgumentException(nameof(channelName));
            if (postId < 1)
                throw new ArgumentException(nameof(postId));

            var url = $"https://t.me/{channelName}/{postId}?embed=1";

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException(nameof(channelName));
            }

            return await new HtmlWeb().LoadFromWebAsync(url);
        }

        protected TelegramPost Parse(HtmlDocument htmlDocument)
        {
            if (htmlDocument == null) return null;

            var divText = htmlDocument.DocumentNode.Descendants("div")
                .LastOrDefault(m => m.HasClass("tgme_widget_message_text"));

            var video = htmlDocument.DocumentNode.Descendants("video")?
                .LastOrDefault();

            var aPhoto = htmlDocument.DocumentNode.Descendants("a")
                .FirstOrDefault(m => m.HasClass("tgme_widget_message_photo_wrap"))
                    ?? htmlDocument.DocumentNode.Descendants("i")
                        .FirstOrDefault(m => m.HasClass("link_preview_image"));

            var iSticker = htmlDocument.DocumentNode.Descendants("i")
                .FirstOrDefault(m => m.HasClass("tgme_widget_message_sticker"));

            var aDocument = htmlDocument.DocumentNode.Descendants("a")
                .FirstOrDefault(m => m.HasClass("tgme_widget_message_document_wrap"));

            if (aPhoto == null && divText == null && video == null && iSticker == null && aDocument == null)
            {
                // log ("Post {0} has no photo an no message Text.", postId);
                return null;
            }

            // log "Parsing post {0}. ", postId;
            var spans = htmlDocument.DocumentNode.Descendants("span")?.ToList();

            var athuorNode = spans?.LastOrDefault(m => m.HasClass("tgme_widget_message_from_author"));
            var dateNode = spans?
                .SingleOrDefault(s => s.HasClass("tgme_widget_message_meta"))?.Descendants("a")?
                .SingleOrDefault(s => s.HasClass("tgme_widget_message_date"))?.Descendants("time")?
                .FirstOrDefault();
            var viewNode = spans?.LastOrDefault(m => m.HasClass("tgme_widget_message_views"));

            var post = new TelegramPost
            {
                Id = ParsePostId(htmlDocument),
                PostType = video != null ? TelegramPostType.Video :
                    aPhoto != null ? TelegramPostType.Photo :
                    iSticker != null ? TelegramPostType.Sticker :
                    aDocument != null ? TelegramPostType.File : TelegramPostType.Text,
                WebRaw = htmlDocument.ParsedText,
                TextRaw = divText?.InnerText,
                Author = athuorNode?.InnerText ?? string.Empty,
                DateString = dateNode?.InnerText,
                ViewCount = viewNode?.InnerText
            };

            SetAttachmentUri(post, aPhoto, video, iSticker);
            SetTitleBody(post, divText?.InnerHtml);

            if (DateTime.TryParse(dateNode?.Attributes["datetime"]?.Value, out var date))
            {
                post.Date = date;
            }

            return post;
        }

        private int ParsePostId(HtmlDocument htmlDocument)
        {
            var divText = htmlDocument.DocumentNode.Descendants("div")
                .LastOrDefault(m => m.HasClass("tgme_widget_message_link"))?
                .Descendants("a").LastOrDefault();

            var link = divText?.Attributes["href"]?.Value;

            if (!string.IsNullOrWhiteSpace(link))
            {
                var idStr = link.Substring(link.LastIndexOf('/') + 1);

                if (int.TryParse(idStr, out var postId))
                {
                    return postId;
                }
            }

            return 1;
        }

        private void SetAttachmentUri(TelegramPost post, HtmlNode photoNode, HtmlNode videoNode, HtmlNode stickerNode)
        {
            string url = null;

            switch (post.PostType)
            {
                case TelegramPostType.Photo:
                    url = ParsePhotoUrl(photoNode);
                    break;
                case TelegramPostType.Video:
                    url = videoNode?.Attributes["src"]?.Value;
                    break;
                case TelegramPostType.Sticker:
                    url = ParseStickerUrl(stickerNode);
                    break;
            }

            if (!string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                post.AttachmentUri = uri;
            }
        }

        private static string ParsePhotoUrl(HtmlNode photoNode)
        {
            return GetUrlOutOfStyle(photoNode?.Attributes["style"]?.Value);
        }

        private static string ParseStickerUrl(HtmlNode stickerNode)
        {
            return GetUrlOutOfStyle(stickerNode?.Attributes["style"]?.Value);
        }

        private static void SetTitleBody(TelegramPost post, string txt)
        {
            if (post == null)
                return;

            int brIndex = txt.IndexOf("<br", StringComparison.Ordinal);

            if (brIndex > -1)
            {
                post.PossibleTitle = txt.Substring(0, brIndex).RemoveHtmlTags();

                if (post.PostType == TelegramPostType.Text)
                {
                    int afterBrIndex = brIndex + 4; // <br> length = 4
                    post.Body = txt.Substring(afterBrIndex, Math.Max(txt.Length - afterBrIndex, 0));
                }
                else
                    post.Body = txt;
            }
            else
            {
                var possibleTitle = txt.RemoveHtmlTags();

                if (possibleTitle.Length > MAX_TITLE_LENGTH)
                {
                    post.PossibleTitle = possibleTitle.Substring(0, MAX_TITLE_LENGTH);
                    post.Body = txt;
                }
                else
                {
                    post.PossibleTitle = possibleTitle;
                    post.Body = post.PostType == TelegramPostType.Text ? txt : "";
                }
            }
        }

        private static string GetUrlOutOfStyle(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return null;

            // styles is something like "background-image:url('https://cdn4.telesco.pe/file/ZPPsL_...kjhdA.jpg')"
            const string START_STR = "url('";
            var startIndex = style.IndexOf(START_STR, StringComparison.Ordinal);
            if (startIndex == -1) return null;
            startIndex += START_STR.Length;

            const string END_STR = "')";
            var endIndex = style.IndexOf(END_STR, StringComparison.Ordinal);
            if (endIndex == -1) return null;

            var length = endIndex - startIndex;
            if (length < 0 || length > style.Length)
                return null;

            return style.Substring(startIndex, length);
        }
    }
}
