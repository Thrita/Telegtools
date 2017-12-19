using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public static class TelegramClientConfigProvider
    {
        public const string TELEGRAM_API_ID_KEY = "telegram_api_id";
        public const string TELEGRAM_API_HASH_KEY = "telegram_api_hash";
        public const string TELEGRAM_PHONE_NUMBER_KEY = "telegram_phone_number";

        public static TelegramClientConfig GetFromAppConfig()
        {
            var apiId = int.Parse(ConfigurationManager.AppSettings[TELEGRAM_API_ID_KEY]);
            var apiHash = ConfigurationManager.AppSettings[TELEGRAM_API_HASH_KEY];
            var phoneNumber = ConfigurationManager.AppSettings[TELEGRAM_PHONE_NUMBER_KEY];

            return new TelegramClientConfig(apiId, apiHash, phoneNumber);
        }
    }
}
