using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Thrita.Telegtools.EntityFramework
{
    public sealed class JobAttachmentManager : JobManagerBase
    {
        private readonly ITelegramPostSaver _attachmentTools;

        public JobAttachmentManager(IChannelTools channelTools, ITelegramPostSaver attachmentTools)
            : base(channelTools)
        {
            _attachmentTools = attachmentTools;
        }

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
                    var post = await ChannelTools.GetPostAsync(job.ChannelName, postId);
                    var log = new TelegtoolsLog(job.ChannelName, postId) { TelegtoolsJobId = job.Id };

                    if (post == null)
                    {
                        log.Level = TraceLevel.Warning;
                        log.Message = $"Could not read post {postId}.";
                    }

                    try
                    {
                        if (post?.AttachmentUri != null && post.PostType == TelegramPostType.Video)
                        {
                            await _attachmentTools.SaveAsync(post);
                            log.Level = TraceLevel.Info;
                            log.Message = $"Attachemnt of post {postId} has been saved.";
                        }
                        else
                        {
                            log.Level = TraceLevel.Warning;
                            log.Message = $"Post {postId} does not have any attachment.";
                        }

                        using (var ctx = new TelegtoolsContext())
                        {
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
                        catch {/* ignored */}
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
