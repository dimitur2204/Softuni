
namespace StorageMasterTests
{
    using NUnit.Framework;
    using FluentAssertions;
    using System;

    using StorageMaster.Entities.Factories;
    using StorageMaster.Entities.Products;


    [TestFixture]
    public class ProductFactoryTests
    {
        private ProductFactory productFactory = new ProductFactory();
        [Test]
        public void DoesCreateProductMethodThrowExceptionWhenMissingProductIsWanted()
        {
            Assert.Throws<InvalidOperationException>(() => productFactory.CreateProduct("NoSuchProduct", 100));
        }
        [Test]
        public void DoesCreateProductMethodReturnProductsCorrectly()
        {
            var gpu = productFactory.CreateProduct("Gpu",100);
            gpu.Should().BeOfType(typeof(Gpu));
        }
    }
}
