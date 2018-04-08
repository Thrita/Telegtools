using NUnit.Framework;
using System.Linq;
using System;

namespace Thrita.Telegtools.EntityFramework.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            using (var ctx = new TelegtoolsContext())
            {
                int actual = ctx.TelegramPosts.Count();
            }
        }

        [Test]
        public void ExecuteJobAsync()
        {
            var jobMan = new JobManager(new WebChannelTools());
            var jobTask = jobMan.CreateJobAsync("telegram", 3, 7);
            jobTask.Wait();
            var job = jobTask.Result;

            var task = jobMan.ExecuteJobAsync(job.Id);
            System.Threading.Thread.Sleep(2000);

            using (var ctx = new TelegtoolsContext())
            {
                var jobNow = ctx.Jobs.Find(job.Id);
                Assert.AreEqual(TelegtoolsJobStatus.InProcess, jobNow?.Status);
            }

            task.Wait();
            job = task.Result;

            Assert.AreEqual(TelegtoolsJobStatus.Done, job.Status);
            Assert.NotNull(job.EndDate);
        }
    }
}
