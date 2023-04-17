using YTM_YTC_Calculator.Domain;
using YTM_YTC_Calculator.Helpers;
using YTM_YTC_Calculator.Services.DateService;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

internal class YTMWithoutCouponStrategy : IYieldStrategy
{
    private readonly IDateService _dateService;

    public string Tag => YieldStrategyRepositoryHelper.GenerateTag(Constants.YTM_StrategyName, false);
    public YTMWithoutCouponStrategy(IDateService dateService)
    {
        _dateService = dateService;
    }


    public double CalculateYield(CalculateYieldArgument arg) => (Math.Pow(arg.FaceValue / arg.PurchaseValue, 365 / _dateService.DateDiff(arg.CallDate, arg.MaturityDate)) - 1) * 100;
}
