using YTM_YTC_Calculator.Domain;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService;

internal sealed class YieldCalculatorService : IYieldCalculatorService
{
    private readonly YieldStrategyFactory _yieldStrategyFactory;

    public YieldCalculatorService(YieldStrategyFactory yieldStrategyFactory)
    {
        _yieldStrategyFactory = yieldStrategyFactory;
    }

    public double CalculateYTC(StockData stockData, Asset asset, string callDate)
        => _yieldStrategyFactory.CreateStrategy(Constants.YTC_StrategyName, asset.HasCoupon)
            .CalculateYield(CalculateYieldArgument.Create(
                stockData.LastPrice,
                stockData.LastPriceTransaction,
                asset.MaturityDate,
                callDate));


    public double CalculateYTM(StockData stockData, Asset asset, string callDate)
        => _yieldStrategyFactory.CreateStrategy(Constants.YTM_StrategyName, asset.HasCoupon)
            .CalculateYield(CalculateYieldArgument.Create(
                stockData.LastPrice,
                stockData.LastPriceTransaction,
                asset.MaturityDate,
                callDate));
}