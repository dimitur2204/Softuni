
namespace InStockTests
{
    using NUnit.Framework;
    using System;

    using InStock;
    using FluentAssertions;

    [TestFixture]
    public class ProductTests
    {

        [Test]
        public void Constructor_ShouldThrowExceptionWhenLabelValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null,12,12));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void Constructor_ShouldThrowExceptionWhenPriceValueIsLessOrEqualToZero(decimal price)
        {
            Assert.Throws<ArgumentException>(() => new Product("MyLabel", price, 12));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void Constructor_ShouldThrowExceptionWhenQuantitiyValueIsLessOrEqualToZero(int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product("MyLabel", 12, quantity));
        }
        [Test]
        public void Constructor_ShouldSetFieldsCorrectlyWhenGivenProperValues()
        {
            var product = new Product("MyLabel",12,12);
            product.Label.Should().Be("MyLabel");
            product.Price.Should().Be(12);
            product.Quantity.Should().Be(12);
        }
        
    }
}
