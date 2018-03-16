using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public interface IChannelTools
    {
        TelegramPost GetPost(string channelName, int postId);
        Task<TelegramPost> GetPostAsync(string channelName, int postId);
    }
}
