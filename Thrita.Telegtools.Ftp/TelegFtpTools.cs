using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Ftp
{
    public class TelegFtpTools : IAttachmentTools
    {
        private readonly string _ftpUrl;
        private readonly string _ftpUser;
        private readonly string _ftpPwd;

        public TelegFtpTools(string ftpUrl = null, string ftpUser = null, string ftpPwd = null)
        {
            var appSettings = ConfigurationManager.AppSettings;
            _ftpUrl = ftpUrl ?? appSettings["ftp_url"];
            _ftpUser = ftpUser ?? appSettings["ftp_username"];
            _ftpPwd = ftpPwd ?? appSettings["ftp_password"];
        }

        public void Save(TelegramPost telegramPost)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(TelegramPost telegramPost)
        {
            if (telegramPost == null) throw new ArgumentNullException(nameof(telegramPost));
            if (telegramPost.AttachmentUri == null) return;

            switch (telegramPost.PostType)
            {
                case TelegramPostType.Text:
                    break;
                case TelegramPostType.Photo:
                    await SaveFileToFtpAsync(telegramPost);
                    break;
                case TelegramPostType.Video:
                    await SaveFileToFtpAsync(telegramPost);
                    break;
                case TelegramPostType.File:
                    throw new NotImplementedException();
                case TelegramPostType.Sticker:
                    throw new NotImplementedException();
            }
        }

        private async Task SaveFileToFtpAsync(TelegramPost telegramPost)
        {
            var path = UploadPath(telegramPost);
            var req = WebRequest.Create(telegramPost.AttachmentUri);

            using (var response = req.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        //var image = Image.FromStream(stream);
                        await UploadFileToFtp(stream, path);
                    }
                }
            }
        }

        private string UploadPath(TelegramPost post)
        {
            if (post?.AttachmentUri == null) return string.Empty;
            var dotIndex = post.AttachmentUri.ToString().LastIndexOf('.');
            if (dotIndex == -1) return string.Empty;
            var ext = post.AttachmentUri.ToString().Substring(dotIndex);
            return $"/{post.Date.Year}/{post.Id}{ext}";
        }

        private async Task UploadFileToFtp(Stream stream, string path)
        {
            string ftpfullpath = Path.Combine(_ftpUrl + path);
            var ftp = (FtpWebRequest)WebRequest.Create(ftpfullpath);
            ftp.Credentials = new NetworkCredential(_ftpUser, _ftpPwd);
            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            byte[] buffer = await ReadFully(stream);

            using (var ftpstream = ftp.GetRequestStream())
            {
                await ftpstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        private static async Task<byte[]> ReadFully(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
