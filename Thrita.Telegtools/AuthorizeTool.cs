using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;

namespace Thrita.Telegtools
{
    public class AuthorizeTool
    {
        private static TelegramClient _client;

        public AuthorizeTool() : this(TelegramClientProvider.GetTelegramClient()) { }

        public AuthorizeTool(TelegramClient telegramClient)
        {
            _client = telegramClient;
        }

        public async Task<string> AuthorizeAsyncStep1()
        {
            var phoneNumber = TelegramClientConfigProvider.GetFromAppConfig().PhoneNumber;
            await _client.ConnectAsync();
            return await _client.SendCodeRequestAsync(phoneNumber); // returns 'hash'
        }

        public async Task AuthorizeAsyncStep2(string hashFromStep1, string loginCode)
        {
            var phoneNumber = TelegramClientConfigProvider.GetFromAppConfig().PhoneNumber;
            await AuthorizeAsyncStep2(phoneNumber, hashFromStep1, loginCode);
        }

        internal protected async Task<TLUser> AuthorizeAsyncStep2(string phoneNumber, string hashFromStep1, string loginCode)
        {
            await _client.ConnectAsync();
            return await _client.MakeAuthAsync(phoneNumber, hashFromStep1, loginCode);
        }
    }
}
