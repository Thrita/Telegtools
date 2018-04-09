using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Tlt
{
    internal class DiskWriter : ITelegramPostSaver
    {
        private readonly string _directory;

        public DiskWriter(string directory)
        {
            _directory = directory;
        }

        public void Save(TelegramPost telegramPost)
        {
            using (var file = File.CreateText(Path.Combine(_directory, $"{telegramPost.Id}.json")))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, telegramPost);
            }

            using (var file = File.CreateText(Path.Combine(_directory, $"{telegramPost.Id}.txt")))
            {
                file.Write(telegramPost.TextRaw);
            }
        }

        public Task SaveAsync(TelegramPost telegramPost)
        {
            throw new NotImplementedException();
        }
    }
}
