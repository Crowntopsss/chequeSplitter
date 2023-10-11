namespace ChequeSplitterLibrary
{
    public class ChequeSplitter
    {
        public decimal SplitCheque(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople <= 0) throw new ArgumentException("Number of people must be greater than 0");
            return Math.Round(amount / numberOfPeople, 2);
        }
    }
}
