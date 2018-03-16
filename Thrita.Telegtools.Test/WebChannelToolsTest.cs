using System;
using System.Threading;
using NUnit.Framework;

namespace Thrita.Telegtools.Test
{
    [TestFixture]
    public class WebChannelToolsTest
    {
        [Test]
        public void GetPost_One_Line_Text_Test()
        {
            var webChannelTools = new WebChannelTools();

            var actual = webChannelTools.GetPost("telegram", 3);

            Assert.IsNotNull(actual);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.Body);
            Assert.AreEqual(TelegramPostType.Text, actual.PostType);
            Assert.IsNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-09-21T02:15:20+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Sep 21, 2015 at 02:15", actual.DateString);
            Assert.AreEqual(3, actual.Id);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.PossibleTitle);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
        }

        [Test]
        public void GetPostAsync_One_Line_Text_Test()
        {
            var webChannelTools = new WebChannelTools();

            var tsk = webChannelTools.GetPostAsync("telegram", 3);
            tsk.Wait();
            var actual = tsk.Result;

            Assert.IsNotNull(actual);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.Body);
            Assert.AreEqual(TelegramPostType.Text, actual.PostType);
            Assert.IsNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-09-21T02:15:20+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Sep 21, 2015 at 02:15", actual.DateString);
            Assert.AreEqual(3, actual.Id);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.PossibleTitle);
            Assert.AreEqual("This thing is about to become the official Telegram channel on Telegram.", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
        }

        [Test]
        public void GetPost_Multiline_Text_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 10);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            Assert.AreEqual(TelegramPostType.Text, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual(@"<br>This bot will now also give you usage statistics for your stickers and packs. Try feeding it the new commands:<br>/stats<br>/top<br>/packstats<br>/packtop<br><br>Stickers bot:<br><a href=""https://telegram.me/stickers"" target=""_blank"" rel=""noopener"">https://telegram.me/stickers</a><br>An introduction to sticker packs:<br><a href=""https://telegram.org/blog/stickers-revolution"" target=""_blank"" rel=""noopener"">https://telegram.org/blog/stickers-revolution</a>", actual.Body);
            Assert.IsNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-09-24T13:30:23+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Sep 24, 2015 at 13:30", actual.DateString);
            Assert.AreEqual(10, actual.Id);
            Assert.AreEqual("Good news for artists: We&#39;ve upgraded the @Stickers bot, which helps you create sticker packs from your pictures.", actual.PossibleTitle);
            Assert.AreEqual("Good news for artists: We&#39;ve upgraded the @Stickers bot, which helps you create sticker packs from your pictures.This bot will now also give you usage statistics for your stickers and packs. Try feeding it the new commands:/stats/top/packstats/packtopStickers bot:https://telegram.me/stickersAn introduction to sticker packs:https://telegram.org/blog/stickers-revolution", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_Multiline_Forwarded_Text_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 17);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            Assert.AreEqual(TelegramPostType.Text, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.IsTrue(actual.Body.StartsWith("<br>A couple of weeks ago Telegram stopped working in Iran, so I assumed we had been blocked there."));
            Assert.IsTrue(actual.Body.EndsWith(@"<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F8C9F.png')""><b>🌟</b></i>"));
            Assert.IsNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-11-04T17:56:29+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Nov 4, 2015 at 17:56", actual.DateString);
            Assert.AreEqual(17, actual.Id);
            Assert.AreEqual("Finally some good news for our Iranian users.", actual.PossibleTitle);
            Assert.IsTrue(actual.TextRaw.StartsWith("Finally some good news for our Iranian users.A couple of weeks ago "));
            Assert.IsTrue(actual.TextRaw.EndsWith("Iran. For now. And let’s hope for the best 🌟"));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_Photo_Only_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 16);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            Assert.AreEqual(TelegramPostType.Photo, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("", actual.Body);
            Assert.IsNotNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-10-16T22:16:38+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Oct 16, 2015 at 22:16", actual.DateString);
            Assert.AreEqual(16, actual.Id);
            Assert.AreEqual("", actual.PossibleTitle);
            Assert.AreEqual("", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_Photo_with_Text_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 86);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            //todo: gif anim is selected as video! Assert.AreEqual(TelegramPostType.Photo, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("", actual.Body);
            Assert.IsNotNull(actual.AttachmentUri);
            //todo: Assert.AreEqual(DateTime.Parse("2015-10-16T22:16:38+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            //todo: Assert.AreEqual("Oct 16, 2015 at 22:16", actual.DateString);
            Assert.AreEqual(86, actual.Id);
            Assert.AreEqual("This video should give you an idea of how the new account switching feature works – available on Android today and coming soon to other platforms. ✨🌟⭐️ Happy holidays&#33;", actual.PossibleTitle);
            Assert.AreEqual("This video should give you an idea of how the new account switching feature works – available on Android today and coming soon to other platforms. ✨🌟⭐️ Happy holidays&#33;", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_Video_with_Text_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 90);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            Assert.AreEqual(TelegramPostType.Video, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("", actual.Body);
            Assert.IsNotNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2018-02-01T18:09:24+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Feb 1 at 18:09", actual.DateString);
            Assert.AreEqual(90, actual.Id);
            Assert.AreEqual("Here&#39;s a video demo to give you a taste of Telegram X for Android.", actual.PossibleTitle);
            Assert.AreEqual("Here&#39;s a video demo to give you a taste of Telegram X for Android.", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_File_Only_Test()
        {
            var webChannelTools = new WebChannelTools();
            var actual = webChannelTools.GetPost("telegram", 35);

            Assert.IsNotNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
            Assert.AreEqual(TelegramPostType.File, actual.PostType);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual(string.Empty, actual.Body);
            //todo: Assert.IsNotNull(actual.AttachmentUri);
            //todo: Assert.AreEqual(DateTime.Parse("2018-02-01T18:09:24+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            //todo: Assert.AreEqual("Feb 1 at 18:09", actual.DateString);
            Assert.AreEqual(35, actual.Id);
            //todo: Assert.AreEqual(string.Empty, actual.PossibleTitle);
            //todo: Assert.AreEqual(string.Empty, actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
        }

        [Test]
        public void GetPost_Sticker_Test()
        {
            var webChannelTools = new WebChannelTools();

            var actual = webChannelTools.GetPost("telegram", 4);

            Assert.IsNotNull(actual);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("", actual.Body);
            Assert.AreEqual(TelegramPostType.Sticker, actual.PostType);
            Assert.IsNotNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-09-21T02:17:40+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Sep 21, 2015 at 02:17", actual.DateString);
            Assert.AreEqual(4, actual.Id);
            Assert.AreEqual("", actual.PossibleTitle);
            Assert.AreEqual("", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
        }

        [Test]
        public void GetPostAsync_Sticker_Test()
        {
            var webChannelTools = new WebChannelTools();

            var tsk = webChannelTools.GetPostAsync("telegram", 4);
            tsk.Wait();
            var actual = tsk.Result;

            Assert.IsNotNull(actual);
            Assert.AreEqual(string.Empty, actual.Author);
            Assert.AreEqual("", actual.Body);
            Assert.AreEqual(TelegramPostType.Sticker, actual.PostType);
            Assert.IsNotNull(actual.AttachmentUri);
            Assert.AreEqual(DateTime.Parse("2015-09-21T02:17:40+00:00", Thread.CurrentThread.CurrentCulture), actual.Date);
            Assert.AreEqual("Sep 21, 2015 at 02:17", actual.DateString);
            Assert.AreEqual(4, actual.Id);
            Assert.AreEqual("", actual.PossibleTitle);
            Assert.AreEqual("", actual.TextRaw);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
        }


        [TestCase(TestData.TextPost)]
        [TestCase(TestData.TextReplyPost)]
        [TestCase(TestData.TextWithPhotoPost)]
        [TestCase(TestData.PhotoWithText)]
        [TestCase(TestData.DirectVideoPost)]
        [TestCase(TestData.LinkedVideoPost)]
        public void Parse(string rawHtml)
        {
            var webChannelTools = new WebChannelTools();

            var actual = webChannelTools.Parse(rawHtml);

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Author);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.Body));
            Assert.IsTrue(actual.PostType == TelegramPostType.Photo || actual.PostType == TelegramPostType.Video
                ? actual.AttachmentUri.IsWellFormedOriginalString()
                : true);
            Assert.IsTrue(actual.PostType == TelegramPostType.Text || actual.PostType == TelegramPostType.File
                ? actual.AttachmentUri == null
                : true);
            Assert.IsNotNull(actual.Date);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.DateString));
            Assert.AreNotEqual(1, actual.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.PossibleTitle));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.TextRaw));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.ViewCount));
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual.WebRaw));
        }
    }
}
