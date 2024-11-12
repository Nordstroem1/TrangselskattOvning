using TrängselskattGBG;
using TrängselSkattGbg.Test;
using Xunit.Abstractions;

namespace TrängelSkattGbg.Test
{
    public class TrangelskattLogikTest : IClassFixture<TrangselSkattLogikFixture>
    {
        private readonly TrangselSkattLogik _trangelskattLogik;
        private readonly ITestOutputHelper _outputHelper;
        public TrangelskattLogikTest(TrangselSkattLogikFixture fixture, ITestOutputHelper output)
        {
            _trangelskattLogik = fixture.TrangselSkattLogik;
            _outputHelper = output;
        }

        [Trait("SkattKalkylator", "CalculateTotalCost")]
        [Theory]
        [InlineData("2023-10-15T17:30:00")]
        public void RäknaTotalBeloppShouldReturn13krWhemPassingbetween1700_1759(string dateString)
        {
            int expectedCost = 13;
            var result = _trangelskattLogik.CalculateCostBasedOnTime(dateString);

            _outputHelper.WriteLine($"Expected cost: {expectedCost}");
            Assert.Equal(expectedCost, result);
        }
        [Trait("SkattKalkylator", "CalculateTotalCost")]
        [Theory]
        [InlineData("2023-05-31 08:00, 2023-05-31 12:00, 2023-05-31 12:45, 2023-05-31 17:45")]
        public void RäknaTotalBeloppShouldReturn42kr(string dateString)
        {
            int expectedCost = 42;
            var result = _trangelskattLogik.CalculateCostBasedOnTime(dateString);

            _outputHelper.WriteLine($"Expected cost: {expectedCost}");
            Assert.Equal(expectedCost, result);
        }
        [Trait("SkattKalkylator", "CalculateTotalCost")]
        [Theory]
        [InlineData("2023-05-31 07:00, 2023-05-31 07:10, 2023-05-31 07:20, 2023-05-31 07:30")]
        public void RäknaTotalBeloppShouldReturn60kr(string dateString)
        {
            int expectedCost = 60;
            var result = _trangelskattLogik.CalculateCostBasedOnTime(dateString);

            _outputHelper.WriteLine($"Expected cost: {expectedCost}");
            Assert.Equal(expectedCost, result);
        } 
        
        [Trait("SkattKalkylator", "CalculateTotalCost")]
        [Theory]
        [InlineData("2023-05-31 07:00, 2023-05-31 07:10, 2023-05-31 07:20, 2023-05-31 07:30, 2023-05-31 07:00, 2023-05-30 07:10, 2023-05-30 07:20, 2023-05-30 07:30, 2023-05-30 09:35 ")]
        public void RäknaTotalBeloppShouldReturn120kr(string dateString)
        {
            int expectedCost = 120;
            var result = _trangelskattLogik.CalculateCostBasedOnTime(dateString);

            _outputHelper.WriteLine($"Expected cost: {expectedCost}");
            Assert.Equal(expectedCost, result);
        }
    }
}