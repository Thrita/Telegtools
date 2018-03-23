using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools.EntityFramework
{
    public static class WebChannelToolsExtension
    {
        public static async Task GetPostsAndSaveAsync(
            this WebChannelTools chennelTool,
            TelegtoolsContext context,
            string channelName,
            int startPostId,
            int endPostId)
        {
            if (chennelTool == null) throw new ArgumentNullException(nameof(chennelTool));

            var job = new TelegtoolsJob(channelName);
            context.Jobs.Add(job);
            await context.SaveChangesAsync();
            int postId = -1;

            try
            {
                for (postId = startPostId; postId <= endPostId; postId++)
                {
                    var telegramPost = await chennelTool.GetPostAsync(channelName, postId);
                    var log = new TelegtoolsLog(channelName, postId);

                    if (telegramPost == null)
                    {
                        log.Level = TraceLevel.Warning;
                        log.Message = $"Could not read post {postId}.";
                        job.Logs.Add(log);
                    }
                    else
                    {
                        context.TelegramPosts.Add(telegramPost);
                        log.Level = TraceLevel.Info;
                        log.Message = $"Post {postId} has been saved.";
                        job.Logs.Add(log);
                    }

                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logEx = new TelegtoolsLog(channelName, postId);
                        logEx.Level = TraceLevel.Error;
                        logEx.Message = ex.ToString();
                        job.Logs.Add(log);
                    }
                }
            }
            catch (Exception ex)
            {
                var logEx = new TelegtoolsLog(channelName, postId);
                logEx.Level = TraceLevel.Error;
                logEx.Message = ex.ToString();
                job.Logs.Add(logEx);
            }
            finally
            {
                job.EndDate = DateTime.UtcNow;
                job.Status = TelegtoolsJobStatus.Done;
                await context.SaveChangesAsync();
            }
        }
    }
}
