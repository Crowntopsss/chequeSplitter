using Xunit;
using ChequeSplitterLibrary;

namespace ChequeSplitterTests
{
    public class ChequeSplitterTests
    {
        private readonly ChequeSplitter _chequeSplitter = new ChequeSplitter();

        [Theory]
        [InlineData(100, 4, 25)]
        [InlineData(50, 2, 25)]
        [InlineData(200, 5, 40)]
        public void SplitCheque_ShouldReturnCorrectAmount(decimal amount, int numberOfPeople, decimal expectedResult)
        {
            var result = _chequeSplitter.SplitCheque(amount, numberOfPeople);
            Assert.Equal(expectedResult, result);
        }

        // New tests
        [Fact]
        public void CalculateTip_ShouldReturnCorrectTipAmounts()
        {
            var chequeSplitter = new ChequeSplitter();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 50m },
                { "Bob", 30m },
                { "Charlie", 20m }
            };
            var tipPercentage = 20f;
            var expectedTips = new Dictionary<string, decimal>
            {
                { "Alice", 10m },
                { "Bob", 6m },
                { "Charlie", 4m }
            };
            var actualTips = chequeSplitter.CalculateTip(mealCosts, tipPercentage);
            Assert.Equal(expectedTips, actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldHandleEmptyDictionary()
        {
            var chequeSplitter = new ChequeSplitter();
            var actualTips = chequeSplitter.CalculateTip(new Dictionary<string, decimal>(), 20f);
            Assert.Empty(actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldThrowArgumentExceptionForNegativeTipPercentage()
        {
            var chequeSplitter = new ChequeSplitter();
            Assert.Throws<ArgumentException>(() => chequeSplitter.CalculateTip(new Dictionary<string, decimal>(), -10f));
        }
    }
}
