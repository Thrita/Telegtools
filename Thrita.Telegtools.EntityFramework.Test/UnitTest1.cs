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
            var ctx = new TelegtoolsContext();

            int actual = ctx.TelegramPosts.Count();

            Assert.IsTrue(true);
        }
    }
}
