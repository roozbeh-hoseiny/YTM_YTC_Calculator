using YTM_YTC_Calculator.Domain;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

internal interface IYieldStrategy
{
    string Tag { get; }
    double CalculateYield(CalculateYieldArgument arg);
}
