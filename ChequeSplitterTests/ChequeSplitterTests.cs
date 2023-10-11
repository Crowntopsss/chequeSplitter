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
    }
}
