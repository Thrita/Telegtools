using System;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;

namespace Thrita.Telegtools
{
    public class AuthorizeTool
    {
        private TelegramClient _client;
        private string _step1Hash;
        private string _phoneNumber;

        public AuthorizeTool() : this(TelegramClientProvider.GetTelegramClient()) { }

        public AuthorizeTool(TelegramClient telegramClient)
        {
            _client = telegramClient;
        }

        public async Task AuthorizeAsyncStep1()
        {
            _phoneNumber = TelegramClientConfigProvider.GetFromAppConfig().PhoneNumber;
            await _client.ConnectAsync();
            _step1Hash = await _client.SendCodeRequestAsync(_phoneNumber); // returns 'hash'
        }

        public async Task AuthorizeAsyncStep2(string loginCode)
        {
            if (string.IsNullOrWhiteSpace(loginCode))
                throw new ArgumentException(nameof(loginCode));

            if (string.IsNullOrWhiteSpace(_phoneNumber) || string.IsNullOrWhiteSpace(_step1Hash))
                throw new Exception("You need to call 'AuthorizeAsyncStep1()' first.");

            await AuthorizeAsyncStep2(_phoneNumber, _step1Hash, loginCode);
            _step1Hash = null;
            _phoneNumber = null;
        }

        internal protected async Task<TLUser> AuthorizeAsyncStep2(string phoneNumber, string hashFromStep1, string loginCode)
        {
            return await _client.MakeAuthAsync(phoneNumber, hashFromStep1, loginCode);
        }
    }
}
