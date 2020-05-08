
namespace StorageMasterTests
{
    using FluentAssertions;
    using NUnit.Framework;

    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;

    [TestFixture]
    public class VehicleTests
    {
        private Semi semi;
        [SetUp]
        public void SetUp()
        {
            semi = new Semi();
        }
        public void LoadTrunk()
        {
            for (int i = 0; i < 10; i++)
            {
                semi.LoadProduct(new HardDrive(50));
            }
        }
        [Test]
        public void DoesConstructorSetCapacityAndTrunkCorrectly()
        {
            semi.Capacity.Should().Be(10);
            semi.Trunk.Should().NotBeNull();
        }
        [Test]
        public void DoesIsFullReturnFalseWhenNotFull()
        {
            semi.IsFull.Should().BeFalse();
        }
        [Test]
        public void DoesIsFullReturnTrueWhenFull()
        {
            LoadTrunk();
            semi.IsFull.Should().BeTrue();
        }
        [Test]
        public void DoesIsEmptyReturnTrueWhenEmpty()
        {
            semi.IsEmpty.Should().BeTrue();
        }
        [Test]
        public void DoesIsEmptyReturnFalseWhenNotEmpty()
        {
            LoadTrunk();
            semi.IsEmpty.Should().BeFalse();
        }
        [Test]
        public void DoesLoadProductThrowExceptionWhenTrunkIsAlreadyFull()
        {
            LoadTrunk();
            Assert.Throws<InvalidOperationException>(() => semi.LoadProduct(new HardDrive(50)));
        }
        [Test]
        public void DoesLoadProductWorkCorrectlyWhenTrunkIsNotFull()
        {
            semi.LoadProduct(new HardDrive(50));
            semi.Trunk.Count.Should().Be(1);
        }
        [Test]
        public void DoesUnloadThrowExceptionWhenTrunkIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => semi.Unload());
        }
        [Test]
        public void DoesUnloadWorkCorrectlyWhenTrunkIsFull()
        {
            LoadTrunk();
            semi.Unload().Should().BeEquivalentTo(new HardDrive(50));
        }
    }
}
