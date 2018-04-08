using System.Data.Entity;
using System.Threading.Tasks;

namespace Thrita.Telegtools.EntityFramework
{
    public abstract class JobManagerBase
    {
        public static readonly TelegtoolsJobStatus[] HangingStatuses =
            {TelegtoolsJobStatus.Created, TelegtoolsJobStatus.InProcess};

        protected readonly IChannelTools ChannelTools;

        protected JobManagerBase(IChannelTools channelTools)
        {
            ChannelTools = channelTools;
        }

        public async Task<TelegtoolsJob> CreateJobAsync(string channelName, int fromPostId, int toPostId)
        {
            var job = new TelegtoolsJob(channelName, fromPostId, toPostId);

            using (var ctx = new TelegtoolsContext())
            {
                //var existJob = await ctx.Jobs.Where(j => j.ChannelName == channelName)
                //    .AnyAsync(j => HangingStatuses.Contains(j.Status));

                //if (existJob)
                //    throw new Exception("There is already an unfinished job for this channel.");

                ctx.Jobs.Add(job);
                await ctx.SaveChangesAsync();
            }

            return job;
        }

        public abstract Task<TelegtoolsJob> ExecuteJobAsync(long jobId);

        public async Task<TelegtoolsJob> GetJobAsync(long jobId, bool includeLogs = false)
        {
            using (var ctx = new TelegtoolsContext())
            {
                return includeLogs ?
                    await ctx.Jobs.Include(j => j.Logs).SingleAsync(j => j.Id == jobId)
                    : await ctx.Jobs.SingleAsync(j => j.Id == jobId);
            }
        }

        protected async Task<TelegtoolsJob> UpdateJob(TelegtoolsJob job)
        {
            using (var ctx = new TelegtoolsContext())
            {
                ctx.Jobs.Attach(job);
                ctx.Entry(job).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }

            return job;
        }

        protected async Task AddLog(TelegtoolsLog log)
        {
            using (var ctx = new TelegtoolsContext())
            {
                ctx.Logs.Add(log);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
