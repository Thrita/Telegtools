using K1inusa.Repository;
using K1inusa.Repository.DataModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Thrita.Telegtools.EntityFramework.Test
{
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void TestMethod1()
        {
            const int start = 5001;
            const int end = 5500;
            IEnumerable<TelegramPost> posts;

            using (var ctx = new TelegtoolsContext())
            {
                var query =
                    from p in ctx.TelegramPosts
                    where p.Id > start && p.Id <= end
                    where p.ChannelName == "k1inusa"
                    group p by p.Id
                    into tmp
                    select tmp.OrderByDescending(t => t.ReadDate).FirstOrDefault();
                posts = query.ToList();
            }

            using (var ctx = new K1inusaContext("Thrita.Telegtools.EntityFramework.DbConnection"))
            {
                var currentPosts = ctx.Contents.Where(c => c.TelegramId > start && c.TelegramId <= end && c.Type == ContentType.General).ToList();

                foreach (var post in posts)
                {
                    if (currentPosts.Any(c => c.Id == post.Id))
                    {
                        foreach (var cPost in currentPosts.Where(c => c.Id == post.Id))
                        {
                            var body = RemoveSignature(post.Body);
                            cPost.Body = string.IsNullOrWhiteSpace(body) ? "_" : body;
                            cPost.TelegramId = post.Id;
                            cPost.Creation = post.Date;
                            //cPost.CreatorUsername = post.Author;
                            cPost.Summary = GetSummary(post.Body);
                            cPost.Title = string.IsNullOrWhiteSpace(post.PossibleTitle) ? cPost.Title : post.PossibleTitle;
                            cPost.Type =
                                post.PostType == TelegramPostType.Photo ? (ContentType)4
                                : post.PostType == TelegramPostType.Video ? (ContentType)5
                                : ContentType.General;
                            cPost.CreateDateStr = ToPersianCalendarStr(post.Date);
                            cPost.Keywords = GetKeywords(post);
                        }
                    }
                    else
                    {
                        ctx.Contents.Add(ConvertToTelegramPost(post));
                    }
                }

                ctx.SaveChanges();
            }
        }

        private static Content ConvertToTelegramPost(TelegramPost post)
        {
            var content = new Content();
            var body = RemoveSignature(post.Body);
            content.Body = string.IsNullOrWhiteSpace(body) ? "_" : body;
            content.TelegramId = post.Id;
            content.Creation = post.Date;
            //content.CreatorUsername = post.Author;
            content.Summary = GetSummary(post.Body);
            content.TelegramId = post.Id;
            content.Title = string.IsNullOrEmpty(post.PossibleTitle) ? "بدون عنوان" : post.PossibleTitle;
            content.Type =
                post.PostType == TelegramPostType.Photo ? (ContentType)4
                : post.PostType == TelegramPostType.Video ? (ContentType)5
                : ContentType.General;
            content.Deactive = false;
            content.Deleted = false;
            content.Keywords = GetKeywords(post);
            content.TelgramUri = new Uri($"https://t.me/k1inusa/{post.Id}");
            content.CreateDateStr = ToPersianCalendarStr(post.Date);

            return content;
        }

        private static string GetKeywords(TelegramPost post)
        {
            return "K1inUSA";
        }

        private static string GetSummary(string postBody)
        {
            if (string.IsNullOrWhiteSpace(postBody))
                return "_";

            int start = postBody.IndexOf("<br><br>", StringComparison.InvariantCultureIgnoreCase);
            if (start == -1)
                return "_";
            else
                start += 8;

            int len = postBody.IndexOf("<br>", start, StringComparison.InvariantCultureIgnoreCase) - start;

            if (len <= 0)
                return "_";
            else if (len > 250)
                return "_";
            else
                return postBody.Substring(start, len);
        }

        private static string RemoveSignature(string postBody)
        {
            if (!string.IsNullOrWhiteSpace(postBody))
                postBody = postBody.Replace(TestData.Signature1, "").Replace(TestData.Signature1, "");
            return postBody;
        }

        private static string ToPersianCalendarStr(DateTime date)
        {
            return $"{ToPersianDigits(pc.GetDayOfMonth(date))} {MonthNames[pc.GetMonth(date) - 1]} {ToPersianDigits(pc.GetYear(date))}";
        }

        private static readonly System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        private static readonly string[] MonthNames = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
        private static string[] PERSIAN_DIGITS = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

        private static string ToPersianDigits(int number)
        {
            return ToPersianDigits(number.ToString());
        }

        private static string ToPersianDigits(string input)
        {
            for (int i = 0; i < PERSIAN_DIGITS.Length; i++)
                input = input.Replace(i.ToString(), PERSIAN_DIGITS[i]);
            return input;
        }
    }
}
