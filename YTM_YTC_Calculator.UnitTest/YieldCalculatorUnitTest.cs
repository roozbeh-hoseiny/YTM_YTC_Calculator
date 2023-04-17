using Microsoft.Extensions.DependencyInjection;
using YTM_YTC_Calculator.DependencyInjection;
using YTM_YTC_Calculator.Domain;

namespace YTM_YTC_Calculator.UnitTest
{
    public class YieldCalculatorUnitTest
    {
        [Fact]
        public void YTM_With_No_Coupon_Must_Be_OK()
        {
            var services = new ServiceCollection();
            services.AddYieldCalculatorServices();

            var serviceProvider = services.BuildServiceProvider();
            var sut = serviceProvider.GetRequiredService<IYieldCalculatorService>();

            var sutResult = sut.CalculateYTM(
                new Domain.StockData() { Symbol = "Golgohar", LastPrice = 1_000_000, LastPriceTransaction = 820_000 }, 
                new Domain.Asset() { MaturityDate = "1394/12/23", HasCoupon = false }, 
                "1393/12/23");

            Assert.True(Math.Round(sutResult, 2) == 21.95);
        }
    }
}