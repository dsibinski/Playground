using System;
using FluentAssertions;
using NUnit.Framework;
using Playground.Warehouse;

namespace Playground.Tests
{
    public class ProductTests
    {
        [Test]
        public void ApplyBlackFridayDiscount_Should_ApplyBlackFridayDiscount_When_CalledOnNewProduct()
        {
            // given
            var product = CreateProduct();
            
            // when
            product.ApplyBlackFridayDiscount();

            // then
            product.Discount.Should().NotBeNull();
            product.Discount.Name.Should().Be("Black Friday");
            product.Discount.PercentageValue.Should().Be(20);
            product.OriginalPrice.Should().NotBe(product.SalesPrice);
            product.SalesPrice.Should().Be(80);
            product.IsAvailable.Should().Be(true);
        }

        private Product CreateProduct()
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Pods",
                OriginalPrice = 100,
                Quantity = 1000
            };
        }
    }
}