using System.Diagnostics;
using YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

namespace YTM_YTC_Calculator.Services.YieldCalculatorService;

internal sealed class YieldStrategyRepository
{
    private Dictionary<string, Type> _repo = new Dictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);

    public bool TryAdd(string tag, Type t)
    {
        if (!typeof(IYieldStrategy).IsAssignableFrom(t)) return false;
        return _repo.TryAdd(tag, t);
    }
    public Type Get(string tag) => _repo.TryGetValue(tag, out var t) && t is not null ? t : throw new UnreachableException($"Can not find strategy with tag '{tag}'");
}
