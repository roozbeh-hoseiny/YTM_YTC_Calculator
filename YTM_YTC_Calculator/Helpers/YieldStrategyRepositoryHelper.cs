namespace YTM_YTC_Calculator.Helpers;

internal static class YieldStrategyRepositoryHelper
{
    internal static string GenerateTag(string strategyType, bool hasCoupon) => $"{strategyType}_{(hasCoupon ? Constants.WithCoupon : Constants.NoCoupon)}";
}
