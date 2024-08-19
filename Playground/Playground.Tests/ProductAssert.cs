using FluentAssertions;
using Playground.Warehouse;

namespace Playground.Tests
{
    class ProductAssert
    {
        private readonly Product _product;

        public ProductAssert(Product product)
        {
            _product = product;
        }

        public ProductAssert HaveDiscount(string name, int value)
        {
            _product.Discount.Should().NotBeNull();
            _product.Discount.Name.Should().Be(name);
            _product.Discount.PercentageValue.Should().Be(value);
            _product.BasePrice.Should().NotBe(_product.SalesPrice);
            return this;
        }
        
        public ProductAssert BeAvailable()
        {
            _product.IsAvailable.Should().BeTrue();
            return this;
        }

        public ProductAssert Cost(decimal price)
        {
            _product.SalesPrice.Should().Be(price);
            return this;
        }
    }
}