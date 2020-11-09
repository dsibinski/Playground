using System;

namespace Playground.Warehouse
{
    public class Discount
    {
        public string Name { get; set; }
        public int PercentageValue { get; set; }

        public Discount(string name, int percentageValue)
        {
            if (percentageValue < 1 || percentageValue > 99)
            {
                throw new ArgumentException("Discount must be between 1 and 99 percent");
            }

            Name = name;
            PercentageValue = percentageValue;
        }
    }
}