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
        public void GetPostsAndSaveAsync()
        {
            using (var ctx = new TelegtoolsContext())
            {
                var tool = new WebChannelTools();
                var task = tool.GetPostsAndSaveAsync(ctx, "telegram", 1, 10);
                task.Wait();
            }
        }
    }
}
