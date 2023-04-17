using YTM_YTC_Calculator.Services.DateService;

namespace YTM_YTC_Calculator.UnitTest
{
    public class DateServiceTest
    {
        [Fact]
        public void ToGregorianDate_Must_Be_True()
        {
            var sut = new DateService();

            var sutResult = sut.ToGregorianDate("1402/01/27");

            Assert.True(sutResult == new DateOnly(2023, 4, 16));
        }

        [Fact]
        public void DateDiff_Must_Be_OK()
        {
            var sut = new DateService();

            var sutResult = sut.DateDiff("1402/01/27", "1402/01/30");

            Assert.True(sutResult == 3);
        }

    }
}