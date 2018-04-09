using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Thrita.Telegtools.EntityFramework;
using Thrita.Telegtools.Ftp;

namespace Thrita.Telegtools.WebApi.Test.Controllers
{
    [TestFixture]
    public class AttachmentsControllerTest
    {
        [Test]
        public void TestMethod1()
        {
            ITelegramPostSaver aTools = new TelegFtpTools();
            IChannelTools cTools = new WebChannelTools();
            var manager = new JobAttachmentManager(cTools, aTools);
            var job = manager.CreateJobAsync("k1inusa", 4902, 5000).Result;

            manager.ExecuteJobAsync(job.Id).Wait();
        }
    }
}
