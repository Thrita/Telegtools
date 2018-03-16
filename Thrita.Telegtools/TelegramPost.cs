using System;

namespace Thrita.Telegtools
{
    public sealed class TelegramPost
    {
        public Guid TelegramPostId { get; set; }

        public int Id { get; set; }

        public string ChannelName { get; set; }

        public string WebRaw { get; set; }

        public string TextRaw { get; set; }

        public TelegramPostType PostType { get; set; }

        public Uri AttachmentUri { get; set; }

        public string Body { get; set; }

        public string PossibleTitle { get; set; }

        public string Author { get; set; }

        public string DateString { get; set; }

        public DateTime Date { get; set; }

        public string ViewCount { get; set; }

        public DateTime ReadDate { get; set; }

        public TelegramPost()
        {
            TelegramPostId = Guid.NewGuid();
        }
    }

    public enum TelegramPostType
    {
        Text = 0,
        Photo = 1,
        Video = 2,
        File = 3,
        Sticker = 4
    }
}
