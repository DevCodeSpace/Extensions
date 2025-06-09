using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class DateComparisonExtensions
    {
        /// Checks if the date matches [other] without considering the time.
        public static bool IsSameDate(this DateTime date, DateTime other) =>
            date.Year == other.Year && date.Month == other.Month && date.Day == other.Day;

        /// Determines if the date is today, disregarding the time.
        public static bool IsToday(this DateTime date) =>
            date.Date == DateTime.Today;

        /// Determines if the date is the day after today, ignoring time.
        public static bool IsTomorrow(this DateTime date) =>
            date.Date == DateTime.Today.AddDays(1);

        /// Determines if the date is the day before today, ignoring time.
        public static bool WasYesterday(this DateTime date) =>
            date.Date == DateTime.Today.AddDays(-1);

        /// Returns a new [DateTime] instance with the specified number of days added.
        public static DateTime AddDays(this DateTime date, int days) =>
            date.AddDays(days); 

        /// Returns a new [DateTime] instance with the specified number of months added.
        public static DateTime AddMonths(this DateTime date, int months) =>
            date.AddMonths(months);

        /// Returns a new [DateTime] instance with the specified number of years added.
        public static DateTime AddYears(this DateTime date, int years) =>
            date.AddYears(years);

        /// Calculates the number of days in the given month of the specified year.
        public static int DaysInMonth(int year, int month) =>
            DateTime.DaysInMonth(year, month);

        /// Checks if the given year is a leap year.
        public static bool IsLeapYear(int year) =>
            DateTime.IsLeapYear(year);

        /// Returns a new [DateTime] instance with the specified number of days subtracted.
        public static DateTime SubtractDays(this DateTime date, int days) =>
            date.AddDays(-days);

        /// Returns a new [DateTime] instance with the specified number of months subtracted.
        public static DateTime SubtractMonths(this DateTime date, int months) =>
            date.AddMonths(-months);

        /// Returns a new [DateTime] instance with the specified number of years subtracted.
        public static DateTime SubtractYears(this DateTime date, int years) =>
            date.AddYears(-years);

        /// Shortcut for obtaining the current date and time.
        public static DateTime Now() => DateTime.Now;

        /// Provides a [DateTime] instance with only the date component, excluding time.
        public static DateTime DateOnly(this DateTime date) =>
            date.Date;

        /// Calculates the time span between [date] and the current moment.
        public static TimeSpan FromNow(this DateTime date) =>
            date - DateTime.Now;

        /// Checks if [date] is before the date of [other], ignoring time.
        public static bool IsBeforeDate(this DateTime date, DateTime other) =>
            date.Date < other.Date;

        /// Checks if [date] is after the date of [other], ignoring time.
        public static bool IsAfterDate(this DateTime date, DateTime other) =>
            date.Date > other.Date;

        /// Determines if [date] is a date in the past, without considering time.
        public static bool IsPast(this DateTime date) =>
            date < DateTime.Now;

        /// Determines if [date] is a future date, without considering time.
        public static bool IsFuture(this DateTime date) =>
            date > DateTime.Now;

        /// Checks if [date] falls in the month preceding the current month.
        public static bool IsInPreviousMonth(this DateTime date) =>
            date.Month == DateTime.Now.AddMonths(-1).Month && date.Year == DateTime.Now.AddMonths(-1).Year;

        /// Checks if [date] falls in the month following the current month.
        public static bool IsInNextMonth(this DateTime date) =>
            date.Month == DateTime.Now.AddMonths(1).Month && date.Year == DateTime.Now.AddMonths(1).Year;

        /// Checks if [date] falls in the year before the current year.
        public static bool IsInPreviousYear(this DateTime date) =>
            date.Year == DateTime.Now.Year - 1;

        /// Checks if [date] falls in the year after the current year.
        public static bool IsInNextYear(this DateTime date) =>
            date.Year == DateTime.Now.Year + 1;

        // Day of the week checks
        public static bool IsMonday(this DateTime date) => date.DayOfWeek == DayOfWeek.Monday;
        public static bool IsTuesday(this DateTime date) => date.DayOfWeek == DayOfWeek.Tuesday;
        public static bool IsWednesday(this DateTime date) => date.DayOfWeek == DayOfWeek.Wednesday;
        public static bool IsThursday(this DateTime date) => date.DayOfWeek == DayOfWeek.Thursday;
        public static bool IsFriday(this DateTime date) => date.DayOfWeek == DayOfWeek.Friday;
        public static bool IsSaturday(this DateTime date) => date.DayOfWeek == DayOfWeek.Saturday;
        public static bool IsSunday(this DateTime date) => date.DayOfWeek == DayOfWeek.Sunday;

        // Month checks
        public static bool IsInJanuary(this DateTime date) => date.Month == 1;
        public static bool IsInFebruary(this DateTime date) => date.Month == 2;
        public static bool IsInMarch(this DateTime date) => date.Month == 3;
        public static bool IsInApril(this DateTime date) => date.Month == 4;
        public static bool IsInMay(this DateTime date) => date.Month == 5;
        public static bool IsInJune(this DateTime date) => date.Month == 6;
        public static bool IsInJuly(this DateTime date) => date.Month == 7;
        public static bool IsInAugust(this DateTime date) => date.Month == 8;
        public static bool IsInSeptember(this DateTime date) => date.Month == 9;
        public static bool IsInOctober(this DateTime date) => date.Month == 10;
        public static bool IsInNovember(this DateTime date) => date.Month == 11;
        public static bool IsInDecember(this DateTime date) => date.Month == 12;
    }
}
