using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using YTM_YTC_Calculator.Helpers;
using YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService;

internal sealed class YieldStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly YieldStrategyRepository _repo;

    public YieldStrategyFactory(IServiceProvider serviceProvider, YieldStrategyRepository repo)
    {
        _serviceProvider = serviceProvider;
        _repo = repo;
    }
    public IYieldStrategy CreateStrategy(string strategyType, bool hasCoupon)
    {
        var tag = _repo.Get(YieldStrategyRepositoryHelper.GenerateTag(strategyType, hasCoupon));
        var result = _serviceProvider.GetRequiredService(tag) as IYieldStrategy;

        return result is not null ? result : throw new UnreachableException($"Can not find strategy with tag '{tag}'");
    }
}
