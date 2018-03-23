using NUnit.Framework;
using System;

namespace Thrita.Telegtools.EntityFramework.Test
{
    [TestFixture]
    public class TelegtoolsJobTest
    {
        [Test]
        public void TelegtoolsJob_Simple_Test()
        {
            var job = new TelegtoolsJob() { Message = "Unit Test" };

            using (var ctx = new TelegtoolsContext())
            {
                ctx.Jobs.Add(job);
                ctx.SaveChanges();

                job.EndDate = DateTime.UtcNow;
                job.Status = TelegtoolsJobStatus.Done;
                ctx.SaveChanges();
            }
        }

        [Test]
        public void TelegtoolsJob_with_a_Log_Test()
        {
            var job = new TelegtoolsJob() { Message = "Unit Test" };
            var log = new TelegtoolsLog();
            job.Logs.Add(log);

            using (var ctx = new TelegtoolsContext())
            {
                ctx.Jobs.Add(job);
                ctx.SaveChanges();

                job.EndDate = DateTime.UtcNow;
                job.Status = TelegtoolsJobStatus.Done;
                ctx.SaveChanges();
            }
        }
    }
}
