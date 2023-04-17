using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using YTM_YTC_Calculator.Domain;
using YTM_YTC_Calculator.Services.DateService;
using YTM_YTC_Calculator.Services.YieldCalculatorService;
using YTM_YTC_Calculator.Services.YieldCalculatorService.Strategies;

namespace YTM_YTC_Calculator.DependencyInjection
{
    internal static class YieldCalculatorServiceCollectionExtension
    {
        public static IServiceCollection AddYieldCalculatorServices(this IServiceCollection services)
        {
            services.TryAddTransient<IDateService, DateService>();
            services.TryAddSingleton<YieldStrategyFactory>();

            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetAssembly(typeof(YTCWithCouponStrategy))!)
                  .AddClasses(classes => classes.AssignableTo<IYieldStrategy>(), publicOnly: false)
                      .AsSelfWithInterfaces()
                      .WithTransientLifetime()
            );

            services.TryAddSingleton(sp =>
            {
                var result = new YieldStrategyRepository();
                var registeredServices = sp.GetServices<IYieldStrategy>();
                if (registeredServices is null) throw new Exception($"Can not find any registered service with type : \"IYieldCalculator\"");

                foreach (var registeredService in registeredServices)
                    result.TryAdd(registeredService.Tag, registeredService.GetType());

                return result;
            });

            services.TryAddScoped<IYieldCalculatorService, YieldCalculatorService>();

            return services;
        }
    }
}
