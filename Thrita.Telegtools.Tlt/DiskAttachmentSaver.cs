﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Tlt
{
    internal class DiskAttachmentSaver : ITelegramPostSaver
    {
        private readonly string _directory;

        public DiskAttachmentSaver(string directory)
        {
            _directory = directory;
        }

        public void Save(TelegramPost telegramPost)
        {
            if (string.IsNullOrWhiteSpace(telegramPost?.AttachmentUri?.AbsolutePath))
                return;

            var req = WebRequest.Create(telegramPost.AttachmentUri);

            using (var response = req.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    //var image = Image.FromStream(stream);
                    if (stream != null)
                    {
                        using (var file = File.Create(SavePath(telegramPost)))
                        {
                            stream.CopyTo(file);
                        }
                    }
                }
            }
        }

        public Task SaveAsync(TelegramPost telegramPost)
        {
            throw new NotImplementedException();
        }

        private string SavePath(TelegramPost post)
        {
            if (post?.AttachmentUri == null) return string.Empty;
            var dotIndex = post.AttachmentUri.ToString().LastIndexOf('.');
            if (dotIndex == -1) return string.Empty;
            var ext = post.AttachmentUri.ToString().Substring(dotIndex);
            return Path.Combine(_directory, $"{post.Id}{ext}");
        }
    }
}
