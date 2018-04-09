using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Thrita.Telegtools.EntityFramework.Test
{
    [TestFixture]
    public class UnitTest2
    {
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
