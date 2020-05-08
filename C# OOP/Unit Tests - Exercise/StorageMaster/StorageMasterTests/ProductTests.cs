
namespace StorageMasterTests
{

    using FluentAssertions;
    using NUnit.Framework;
    using System;

    using StorageMaster.Entities.Products;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void DoesConstructorThrowExceptionWhenNegativePriceIsGiven()
        {
            Assert.Throws<InvalidOperationException>(() => new Gpu(-1));
        }
        [Test]
        public void DoesConstructorSetCorrectValuesSuccessfully()
        {
            var validProduct = new Gpu(100);
            validProduct.Price.Should().Be(100);
        }
    }
}
