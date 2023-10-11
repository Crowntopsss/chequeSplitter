using System;
using System.Collections.Generic;

namespace ChequeSplitterLibrary
{
    public class ChequeSplitter
    {
        
        public decimal SplitCheque(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople <= 0) throw new ArgumentException("Number of people must be greater than 0");
            return Math.Round(amount / numberOfPeople, 2);
        }
        
        
        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage cannot be negative");
            
            var totalCost = 0m;
            foreach (var cost in mealCosts.Values)
            {
                totalCost += cost;
            }
            
            var tipAmounts = new Dictionary<string, decimal>();
            foreach (var entry in mealCosts)
            {
                var name = entry.Key;
                var cost = entry.Value;
                var individualTip = Math.Round(cost / totalCost * (decimal)tipPercentage / 100 * totalCost, 2);
                tipAmounts[name] = individualTip;
            }
            
            return tipAmounts;
        }

        public decimal CalculateIndividualTip(decimal totalAmount, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0) throw new ArgumentException("Number of patrons must be greater than 0");
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage cannot be negative");

            decimal totalTip = totalAmount * (decimal)tipPercentage / 100;
            decimal tipPerPerson = totalTip / numberOfPatrons;
            
            return Math.Round(tipPerPerson, 2);
        }
    }
}
