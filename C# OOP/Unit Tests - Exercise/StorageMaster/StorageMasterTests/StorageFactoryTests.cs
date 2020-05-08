
namespace StorageMasterTests
{
    using NUnit.Framework;
    using System;
    using FluentAssertions;

    using StorageMaster.Entities.Factories;
    using StorageMaster.Entities.Storage;


    [TestFixture]
    public class StorageFactoryTests
    {
        private StorageFactory storageFactory = new StorageFactory();
        [Test]
        public void DoesCreateStorageMethodThrowExceptionWhenInvalidStorageIsGiven()
        {
            Assert.Throws<InvalidOperationException>(() => storageFactory.CreateStorage("NoSuchStorage","SomeRandomName"));
        }
        [Test]
        public void DoesCreateStorageMethodCreateStorageSuccesfully()
        {
            var warehouse = storageFactory.CreateStorage("Warehouse","MyWarehouse");
            warehouse.Should().BeOfType(typeof(Warehouse));
        }
    }
}
