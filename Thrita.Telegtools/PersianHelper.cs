using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools
{
    public static class PersianHelper
    {
        private static readonly PersianCalendar PersianCal = new PersianCalendar();
        private static readonly string[] MonthNames = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
        private static readonly string[] PersianDigits = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

        public static string ToPersianDigits(int number)
        {
            return ToPersianDigits(number.ToString());
        }

        public static string ToPersianDigits(string input)
        {
            for (int i = 0; i < PersianDigits.Length; i++)
                input = input.Replace(i.ToString(), PersianDigits[i]);
            return input;
        }

        private static string ToPersianCalendarStr(DateTime date)
        {
            return $"{ToPersianDigits(PersianCal.GetDayOfMonth(date))} {MonthNames[PersianCal.GetMonth(date) - 1]} {ToPersianDigits(PersianCal.GetYear(date))}";
        }
    }
}
