using System.Globalization;

namespace NadinSoft.Application.Contract.Extension;

public static class DateTimeExtensions
{
    public static string ToPersianDate(this DateTime date, bool withTime = false)
    {
        if (date == DateTime.MinValue)
        {
            return "نامعتبر";
        }
        var persian = new PersianCalendar();
        if (withTime)
        {
            return persian.GetYear(date) + "/" + persian.GetMonth(date).ToString().PadLeft(2, '0') + "/" +
                   persian.GetDayOfMonth(date).ToString().PadLeft(2, '0') + " " +
                   persian.GetHour(date).ToString().PadLeft(2, '0') + ":" +
                   persian.GetMinute(date).ToString().PadLeft(2, '0') + ":" +
                   persian.GetSecond(date).ToString().PadLeft(2, '0');
        }

        return persian.GetYear(date) + "/" + persian.GetMonth(date).ToString().PadLeft(2, '0') + "/" +
               persian.GetDayOfMonth(date).ToString().PadLeft(2, '0');
    }


    public static string ToPersianDateTime(this DateTime date)
    {
        return ToPersianDate(date, true);
    }

}