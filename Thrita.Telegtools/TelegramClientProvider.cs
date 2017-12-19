using TLSharp.Core;

namespace Thrita.Telegtools
{
    internal static class TelegramClientProvider
    {
        public static TelegramClient GetTelegramClient()
        {
            var telegramClientConfig = TelegramClientConfigProvider.GetFromAppConfig();
            return GetTelegramClient(telegramClientConfig);
        }

        public static TelegramClient GetTelegramClient(TelegramClientConfig telegramClientConfig)
        {
            return new TelegramClient(telegramClientConfig.ApiId, telegramClientConfig.ApiHash);
        }
    }
}
