namespace Thrita.Telegtools
{
    public class TelegramClientConfig
    {
        public TelegramClientConfig(int apiId, string apiHash, string phoneNumber)
        {
            ApiId = apiId;
            ApiHash = apiHash;
            PhoneNumber = phoneNumber;
        }

        public int ApiId { get; private set; }
        public string ApiHash { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
