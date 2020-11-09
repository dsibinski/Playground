using System;

namespace Playground.Warehouse
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public Discount Discount { get; set; }
        public int Quantity { get; set; }

        public bool IsAvailable => Quantity > 0;
        public decimal SalesPrice => OriginalPrice - (OriginalPrice * Discount?.PercentageValue / 100) ?? OriginalPrice;

        public void ApplyBlackFridayDiscount()
        {
            Discount = new Discount("Black Friday", 20);
        }

        public void ClearDiscount()
        {
            Discount = null;
        }

        public void Sell()
        {
            if (!IsAvailable)
            {
                throw new OutOfStockException($"Product {Name} is out of stock");
            }
            
            Quantity--;
        }
    }
}