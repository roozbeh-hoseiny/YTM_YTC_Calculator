using YTM_YTC_Calculator.Domain;
using YTM_YTC_Calculator.Helpers;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

internal class YTCWithCouponStrategy : IYieldStrategy
{
    public string Tag => YieldStrategyRepositoryHelper.GenerateTag(Constants.YTC_StrategyName, true);
    public double CalculateYield(CalculateYieldArgument arg) => 0;
}
