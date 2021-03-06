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
            var product = CreateProduct(basePrice: 100);
            
            // when
            product.ApplyBlackFridayDiscount();

            // then
            var productShould = new ProductAssert(product);
            productShould
                .BeAvailable()
                .HaveDiscount("Black Friday", 20)
                .Cost(80);
        }

        private Product CreateProduct(decimal basePrice)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Pods",
                BasePrice = basePrice,
                Quantity = 1000
            };
        }
    }
}