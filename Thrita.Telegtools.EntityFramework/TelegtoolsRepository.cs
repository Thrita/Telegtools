using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools.EntityFramework
{
    public class TelegtoolsRepository : ITelegtoolsRepository
    {
        private readonly IChannelTools _channelTools;

        public TelegtoolsRepository(IChannelTools channelTools)
        {
            _channelTools = channelTools;
        }

        /*
        public static async Task GetPostsAndSaveAsync(
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
        //*/

        public async Task GetPostsAndSaveAsync(TelegtoolsJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            if (string.IsNullOrWhiteSpace(job.ChannelName))
                throw new ArgumentException(nameof(job.ChannelName), nameof(job));

            int postId = -1;

            try
            {
                for (postId = job.FromPostId; postId <= job.ToPostId; postId++)
                {
                    var telegramPost = await _channelTools.GetPostAsync(job.ChannelName, postId);
                    var log = new TelegtoolsLog(job.ChannelName, postId) { TelegtoolsJobId = job.Id };

                    if (telegramPost == null)
                    {
                        log.Level = TraceLevel.Warning;
                        log.Message = $"Could not read post {postId}.";
                    }
                    else
                    {
                        log.Level = TraceLevel.Info;
                        log.Message = $"Post {postId} has been saved.";
                    }

                    try
                    {
                        using (var ctx = new TelegtoolsContext())
                        {
                            if (telegramPost != null)
                                ctx.TelegramPosts.Add(telegramPost);
                            ctx.Logs.Add(log);
                            await ctx.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        var logEx = new TelegtoolsLog(job.ChannelName, postId)
                        {
                            TelegtoolsJobId = job.Id,
                            Level = TraceLevel.Error,
                            Message = ex.ToString()
                        };

                        try
                        {
                            using (var ctx = new TelegtoolsContext())
                            {
                                ctx.Logs.Add(logEx);
                                await ctx.SaveChangesAsync();
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logEx = new TelegtoolsLog(job.ChannelName, postId)
                {
                    TelegtoolsJobId = job.Id,
                    Level = TraceLevel.Error,
                    Message = ex.ToString()
                };

                try
                {
                    using (var ctx = new TelegtoolsContext())
                    {
                        ctx.Logs.Add(logEx);
                        await ctx.SaveChangesAsync();
                    }
                }
                catch
                {
                    // ignored
                }
            }
            finally
            {
                job.EndDate = DateTime.UtcNow;
                job.Status = TelegtoolsJobStatus.Done;

                try
                {
                    using (var ctx = new TelegtoolsContext())
                    {
                        ctx.Jobs.Attach(job);
                        await ctx.SaveChangesAsync();
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        public void Save(TelegramPost telegramPost)
        {
            if (telegramPost == null)
                throw new ArgumentNullException(nameof(telegramPost));

            using (var ctx = new TelegtoolsContext())
            {
                ctx.TelegramPosts.Add(telegramPost);
                ctx.SaveChanges();
            }
        }

        public async Task SaveAsync(TelegramPost telegramPost)
        {
            if (telegramPost == null)
                throw new ArgumentNullException(nameof(telegramPost));

            using (var ctx = new TelegtoolsContext())
            {
                ctx.TelegramPosts.Add(telegramPost);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
