namespace YTM_YTC_Calculator.Domain;

internal interface IYieldCalculatorService
{
    /*
        Note : فرض شده است که اطلاعات بازار در زمان فراخوانی این متد موجود است
     */
    double CalculateYTM(StockData stockData, Asset asset, string callDate);
    double CalculateYTC(StockData stockData, Asset asset, string callDate);
}
