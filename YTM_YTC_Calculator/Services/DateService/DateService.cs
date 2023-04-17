using System.Globalization;

namespace YTM_YTC_Calculator.Services.DateService;

internal interface IDateService
{
    DateOnly ToGregorianDate(string date, CultureInfo? currentCulture = null);
    int DateDiff(string date1, string date2, CultureInfo? culture = null);
}
internal sealed class DateService : IDateService
{
    public static CultureInfo PersianCulture = CultureInfo.CreateSpecificCulture("fa-IR");
    
    public DateOnly ToGregorianDate(string date, CultureInfo? currentCulture = null) => DateOnly.Parse(date, currentCulture ?? PersianCulture);

    public int DateDiff(string date1, string date2, CultureInfo? culture = null) => this.ToGregorianDate(date2).DayNumber - this.ToGregorianDate(date1).DayNumber;

}
