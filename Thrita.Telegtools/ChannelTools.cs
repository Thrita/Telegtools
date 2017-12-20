using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace Thrita.Telegtools
{
    /*
    * Read: https://github.com/sochix/TLSharp#starter-guide
    * Read: https://stackoverflow.com/questions/37189908/how-can-i-get-channel-messages-from-telegram-channels-with-tlsharp
    */

    public class ChannelTools
    {
        private static TelegramClient _client;

        public ChannelTools() : this(TelegramClientProvider.GetTelegramClient()) { }

        public ChannelTools(TelegramClient telegramClient)
        {
            _client = telegramClient;
        }

        //        public async Task<IEnumerable<TLMessage>> GatherChannelHistory(string channelName)
        public async Task GatherChannelHistory(string channelName)
        {
            await _client.ConnectAsync();

            const int LIMIT = 100;
            int maxid = -1;
            var result = new List<TLMessage>();
            IEnumerable<TLMessage> slice;
            int offset = 0;

            do
            {
                slice = await GatherChannelHistory(channelName, offset, maxId: maxid, limit: LIMIT);
                if (slice.Any())
                {
                    result.AddRange(slice);
                    //maxid = slice.Min(m => m.Id);
                    offset = offset + LIMIT;
                }
            } while (slice.Count() == LIMIT);

            //return result;
            int x = result.Count();
            System.IO.File.WriteAllLines(@"TLMSGS.TXT", result.Select(m => TLMessageToString((TLMessage)m)));
        }

        private async Task<IEnumerable<TLMessage>> GatherChannelHistory(string channelName, int offset = 0, int maxId = -1, int limit = 100)
        {
            var dialogs = (TLDialogsSlice)await _client.GetUserDialogsAsync();

            var chat = dialogs.Chats.ToList()
               .OfType<TLChannel>()
               .FirstOrDefault(c => c.Title == channelName);

            if (chat == null)
                throw new Exception($"Cannot find Channel '{channelName}'.");

            if (chat.AccessHash == null)
                throw new Exception($"Cannot access Channel '{channelName}'.");

            var tlAbsMessages =
                 await _client.GetHistoryAsync(
                     new TLInputPeerChannel { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, offset,
                     maxId, limit);

            var tlChannelMessages = (TLChannelMessages)tlAbsMessages;
            var messages = tlChannelMessages.Messages.Cast<TLMessage>().AsEnumerable();
            return messages;

            //var messages = tlChannelMessages.Messages.ToList();
            //var messagesCount = tlChannelMessages.Messages.ToList().Count;

            //System.IO.File.WriteAllLines(@"TLMSGS.TXT", messages.Select(m => TLMessageToString((TLMessage)m)));

            //foreach (TLMessage message in messages)
            //{
            //    if (message.Media == null)
            //    {
            //        //_resultMessages.Add(new ChannelMessage()
            //        //{
            //        //    Id = message.Id,
            //        //    ChannelId = chat.Id,
            //        //    Content = message.Message,
            //        //    Type = EnChannelMessage.Message,
            //        //    Views = message.views,
            //        //});

            //        //Console.WriteLine("MSG ID        :{0}", message.Id);
            //        //Console.WriteLine("TYP           :{0}", "Message");
            //        //Console.WriteLine("VIEWs         :{0}", message.Views);
            //        //Console.WriteLine("Contents      :{0}\n", message.Message);
            //    }
            //    else
            //    {

            //        switch (message.Media.GetType().ToString())
            //        {
            //            case "TeleSharp.TL.TLMessageMediaPhoto":
            //                var tLMessageMediaPhoto = (TLMessageMediaPhoto)message.Media;

            //                //_resultMessages.Add(new TLChannelMessages
            //                //{

            //                //    Id = message.id,
            //                //    ChannelId = chat.id,
            //                //    Content = tLMessageMediaPhoto.caption,
            //                //    Type = EnChannelMessage.MediaPhoto,
            //                //    Views = message.views ?? 0,
            //                //});

            //                Console.WriteLine("MSG ID        :{0}", message.Id);
            //                Console.WriteLine("TYP           :{0}", "MediaPhoto");
            //                Console.WriteLine("VIEWs         :{0}", message.Views);
            //                Console.WriteLine("Contents      :{0}\n", tLMessageMediaPhoto.Caption);
            //                Console.WriteLine("Photo      :{0}\n", tLMessageMediaPhoto.Photo.ToString());

            //                break;
            //            //        case "TeleSharp.TL.TLMessageMediaDocument":
            //            //            var tLMessageMediaDocument = (TLMessageMediaDocument)message.media;

            //            //            _resultMessages.Add(new ChannelMessage()
            //            //            {
            //            //                Id = message.id,
            //            //                ChannelId = chat.id,
            //            //                Content = tLMessageMediaDocument.caption,
            //            //                Type = EnChannelMessage.MediaDocument,
            //            //                Views = message.views ?? 0,
            //            //            });
            //            //            break;
            //            //        case "TeleSharp.TL.TLMessageMediaWebPage":
            //            //            var tLMessageMediaWebPage = (TLMessageMediaWebPage)message.media;
            //            //            string url = string.Empty;
            //            //            if (tLMessageMediaWebPage.webpage.GetType().ToString() != "TeleSharp.TL.TLWebPageEmpty")
            //            //            {
            //            //                var webPage = (TLWebPage)tLMessageMediaWebPage.webpage;
            //            //                url = webPage.url;
            //            //            }

            //            //            _resultMessages.Add(new ChannelMessage
            //            //            {
            //            //                Id = message.id,
            //            //                ChannelId = chat.id,
            //            //                Content = message.message + @" : " + url,
            //            //                Type = EnChannelMessage.WebPage,
            //            //                Views = message.views ?? 0,
            //            //            });
            //            //            break;
            //            default:
            //                break;
            //        }
            //    }

        }


        private String TLMessageToString(TLMessage message)
        {
            var strBuilder = new StringBuilder();

            if (message.Media == null)
            {
                strBuilder.AppendFormat("MSG ID        :{0}", message.Id);
                strBuilder.AppendFormat("TYP           :{0}", "Message");
                strBuilder.AppendFormat("Views         :{0}", message.Views);
                strBuilder.AppendFormat("Contents      :{0}", message.Message);
            }

            return strBuilder.ToString();
        }
    }
}
