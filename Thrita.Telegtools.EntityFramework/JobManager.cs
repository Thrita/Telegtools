using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Thrita.Telegtools.EntityFramework
{
    public class JobManager : JobManagerBase
    {
        public JobManager(IChannelTools channelTools)
            : base(channelTools) { }

        public override async Task<TelegtoolsJob> ExecuteJobAsync(long jobId)
        {
            var job = await GetJobAsync(jobId);

            if (job == null || job.Status != TelegtoolsJobStatus.Created)
                throw new ArgumentException($"There is no job with id '{jobId}' in 'created' status.", nameof(jobId));

            if (string.IsNullOrWhiteSpace(job.ChannelName))
                throw new ArgumentException($"The job with id '{jobId}' has no 'Channel Name'!", nameof(jobId));

            job.Status = TelegtoolsJobStatus.InProcess;
            job.StartDate = DateTime.UtcNow;
            job = await UpdateJob(job);

            int postId = -1;

            try
            {
                for (postId = job.FromPostId; postId <= job.ToPostId; postId++)
                {
                    var telegramPost = await ChannelTools.GetPostAsync(job.ChannelName, postId);
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
                            await AddLog(logEx);
                        }
                        catch { /* ignored */ }
                    }
                }

                job.Status = TelegtoolsJobStatus.Done;
            }
            catch (Exception ex)
            {
                job.Status = TelegtoolsJobStatus.Interrupted;

                var logEx = new TelegtoolsLog(job.ChannelName, postId)
                {
                    TelegtoolsJobId = job.Id,
                    Level = TraceLevel.Error,
                    Message = ex.ToString()
                };

                try
                {
                    await AddLog(logEx);
                }
                catch {/* ignored */}
            }
            finally
            {
                job.EndDate = DateTime.UtcNow;
                job = await UpdateJob(job);
            }

            return job;
        }
    }
}
