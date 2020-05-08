
namespace InStockTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.Collections.Generic;

    using InStock;
    using System;

    [TestFixture]
    public class StockTests
    {
        private Stock stock = new Stock();
        [SetUp]
        public void SetUp()
        {
            this.stock = new Stock();
        }
        [Test]
        public void EmptyConstructor_ShouldInitializeListProperly()
        {
            stock.Count.Should().Be(0);
        }
        [Test]
        public void Constructor_ShouldSetGivenListProperly()
        {
            var list = new List<Product>();
            var product = new Product("MyProduct",12,12);
            list.Add(product);
            var stock = new Stock(list);
            stock.Count.Should().Be(1);
        }
        [Test]
        public void Add_ShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stock.Add(null));
        }
        [Test]
        public void Add_ShouldThrowExceptionWhenProductWithExistingLabelIsTryingToBeAdded()
        {
            var product = new Product("MyLabel", 12, 12);
            stock.Add(product);
            Assert.Throws<InvalidOperationException>(() => stock.Add(new Product("MyLabel", 12, 12)));
        }
        [Test]
        public void Add_ShouldAddProductCorrectlyWhenProductIsNotNull()
        {
            var product = new Product("MyLabel", 12, 12);
            stock.Add(product);
            stock.Count.Should().Be(1);
        }
        [Test]
        public void Contains_ShouldThrowNullExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stock.Contains(null));
        }
        [Test]
        [TestCase("NotMyLabel")]
        [TestCase("mylabel")]
        public void Contains_ShouldReturnFalseWhenProductWithTheSameLabelIsNotContained(string label)
        {
            var product = new Product("MyLabel",12,12);
            var differentProduct = new Product(label,12,13);
            stock.Add(product);
            stock.Contains(differentProduct).Should().BeFalse();
        }
        [Test]
        [TestCase("MyLabel")]
        public void Contains_ShouldReturnTrueWhenProductWithTheSameLabelIsContained(string label)
        {
            var product = new Product("MyLabel", 12, 12);
            var differentProduct = new Product(label, 12, 13);
            stock.Add(product);
            stock.Contains(differentProduct).Should().BeTrue();
        }
        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(1)]
        public void Find_ShouldThrowIndexOutOfRangeExceptionWhenIndexIsInvalid(int index)
        {
            var product = new Product("MyLabel",12,12);
            stock.Add(product);
            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(index));
        }
        [Test]
        [TestCase(0)]
        public void Find_ShouldReturnProductAtIndexWhenIndexIsValid(int index)
        {
            var product = new Product("MyLabel", 12, 12);
            stock.Add(product);
            stock.Find(index).Should().BeEquivalentTo(product);
        }
        [Test]
        public void FindByLabel_ShouldThrowArgumentNullExceptionWhenLabelGivenIsNull()
        {
            var product = new Product("MyLabel",12,12);
            Assert.Throws<ArgumentNullException>(() => stock.FindByLabel(null));
        }
        [Test]
        [TestCase("mylabel")]
        [TestCase("NotMyLabel")]
        public void FindByLabel_ShouldReturnInvalidOperationExceptionWhenProductWithSuchLabelDoesNotExist(string label)
        {
            var product = new Product("MyLabel", 12, 12);
            this.stock.Add(product);
            Assert.Throws<InvalidOperationException>(() => stock.FindByLabel(label));
        }
        [Test]
        [TestCase("MyLabel")]
        public void FindByLabel_ShouldReturnProductWhenProdcutWithSuchLabelExists(string label)
        {
            var product = new Product("MyLabel", 12, 12);
            this.stock.Add(product);
            stock.FindByLabel(label).Should().BeEquivalentTo(product);
        }
        [Test]
        [TestCase(-1,12)]
        [TestCase(12,-1)]
        [TestCase(-1,-1)]
        public void FindAllInPriceRange_ShouldThrowInvalidOperationExceptionWhenOneOfThePricesIsLessThanZero(decimal startPrice,decimal endPrice)
        {
            Assert.Throws<InvalidOperationException>(()=>this.stock.FindAllInPriceRange(startPrice,endPrice));
        }
        [Test]
        [TestCase(1,0.5)]
        [TestCase(12,5)]
        [TestCase(12,12)]
        public void FindAllInPriceRange_ShouldThrowInvalidOperationExceptionWhenFirstPriceIsBiggerOrEqualToTheSecondPrice(decimal startPrice, decimal endPrice)
        {
            Assert.Throws<InvalidOperationException>(() => this.stock.FindAllInPriceRange(startPrice, endPrice));
        }
        [Test]
        [TestCase(0,13)]
        [TestCase(12,13)]
        public void FindAllInPriceRange_ShouldReturnArrayWithAllProductsWithinThePriceRange(decimal startPrice, decimal endPrice)
        {
            var product = new Product("MyLabel", 12, 12);
            var secondProduct = new Product("MeSecondLabel",13,12);
            this.stock.Add(product);
            this.stock.Add(secondProduct);
            this.stock.FindAllInPriceRange(startPrice, endPrice)[0].Should().BeEquivalentTo(product);
            this.stock.FindAllInPriceRange(startPrice, endPrice)[1].Should().BeEquivalentTo(secondProduct);
        }
        [Test]
        [TestCase(-5)]
        [TestCase(0)]
        public void FindAllByPrice_ShouldThrowInvalidOperationExceptionWhenPriceIsLessOrEqualToZero(decimal price)
        {
            var product = new Product("MyLabel",12,12);
            this.stock.Add(product);
            Assert.Throws<InvalidOperationException>(() => this.stock.FindAllByPrice(price));
        }
        [Test]
        [TestCase(11)]
        public void FindAllByPrice_ShouldReturnEmptyCollectionWhenThereAreNoProductsWithThisPrice(decimal price)
        {
            var product = new Product("MyLabel",12,12);
            this.stock.Add(product);
            this.stock.FindAllByPrice(price).Should().BeEmpty();
        }
        [Test]
        [TestCase(12)]
        public void FindAllByPrice_ShouldReturnCollectionWhenThereAreProductsWithThisPrice(decimal price)
        {
            var product = new Product("MyLabel", 12, 12);
            var secondProdcut = new Product("MySecondLabel",12,12);
            this.stock.Add(product);
            this.stock.Add(secondProdcut);
            this.stock.FindAllByPrice(price)[0].Should().BeEquivalentTo(product);
            this.stock.FindAllByPrice(price)[1].Should().BeEquivalentTo(secondProdcut);
        }
        [Test]
        public void FindMostExpensiveProduct_ShouldThrowInvalidOperationExceptionWhenStockIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.stock.FindMostExpensiveProduct());
        }
        [Test]
        public void FindMostExpensiveProduct_ShouldReturnMostExpensiveItemCorrectly()
        {
            var product = new Product("MyLabel", 12, 12);
            var secondProdcut = new Product("MySecondLabel", 13, 12);
            this.stock.Add(product);
            this.stock.Add(secondProdcut);
            this.stock.FindMostExpensiveProduct().Should().BeEquivalentTo(secondProdcut);
        }
    }
}
