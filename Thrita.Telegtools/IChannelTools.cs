using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public interface IChannelTools
    {
        TelegramPost GetPost(string channelName, int postId);
        Task<TelegramPost> GetPostAsync(string channelName, int postId);
    }

    public abstract class ChannelToolsBase : IChannelTools
    {
        public const int MAX_CHANNEL_NAME_LENGTH = 34;
        public const int MAX_TITLE_LENGTH = 250;

        public abstract TelegramPost GetPost(string channelName, int postId);
        public abstract Task<TelegramPost> GetPostAsync(string channelName, int postId);
    }
}
