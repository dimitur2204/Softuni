
namespace StorageMasterTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Moq;
    using System;

    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using StorageMaster.Entities.Products;


    [TestFixture]
    public class StorageTests
    {
        private Warehouse warehouse;
        [SetUp]
        public void SetUp()
        {
            warehouse = new Warehouse("MyWarehouse");
        }
        public void FullStorageSetUp()
        {
            var auto = new AutomatedWarehouse("Auto");
            var truck = auto.GetVehicle(0);
            for (int i = 0; i < 7; i++)
            {
                truck.LoadProduct(new Gpu(100));
            }
            auto.SendVehicleTo(0,warehouse);
            warehouse.UnloadVehicle(3);
            for (int i = 0; i < 7; i++)
            {
                warehouse.GetVehicle(3).LoadProduct(new Gpu(100));
            }
            warehouse.UnloadVehicle(3);
            for (int i = 0; i < 1; i++)
            {
                warehouse.GetVehicle(3).LoadProduct(new Gpu(100));
            }
            warehouse.UnloadVehicle(3);
        }
        [Test]
        public void DoesConstructorInitializeStorageSuccessfully()
        {
            this.warehouse.Capacity.Should().Be(10);
            this.warehouse.GarageSlots.Should().Be(10);
            this.warehouse.Name.Should().Be("MyWarehouse");
        }
        [Test]
        public void DoesIsFullPropertyReturnTrueWhenFull()
        {
            FullStorageSetUp();
            warehouse.IsFull.Should().Be(true);
        }
        [Test]
        public void DoesIsFullPropertyReturnFalseWhenNotFull()
        {
            warehouse.IsFull.Should().Be(false);
        }
        [Test]
        public void DoesGetVehicleThrowExceptionWhenInvalidGarageSlotIsGiven()
        {
            Assert.Throws<InvalidOperationException>(() => warehouse.GetVehicle(11));
        }
        [Test]
        public void DoesGetVehicleThrowExceptionWhenThereIsNoVehicleInGarageSlot()
        {
            Assert.Throws<InvalidOperationException>(() => warehouse.GetVehicle(5));
        }
        [Test]
        public void DoesGetVehicleReturnVehicleCorrectly()
        {
            warehouse.GetVehicle(0).Should().BeOfType(typeof(Semi));
        }
        [Test]
        public void DoesSendVehicleToThrowExceptionWhenThereIsNoFreeSpace()
        {
            var auto = new AutomatedWarehouse("Automated");
            warehouse.SendVehicleTo(0,auto);
            Assert.Throws<InvalidOperationException>(() => warehouse.SendVehicleTo(1,auto));
        }
        [Test]
        public void DoesSendVehicleToWorkCorrectlyWhenThereIsFreeGarageSlot()
        {
            var auto = new AutomatedWarehouse("Automated");
            warehouse.SendVehicleTo(0, auto);
            auto.GetVehicle(1).Should().BeOfType(typeof(Semi));
        }
        [Test]
        public void DoesUnloadVehicleThrowExceptionWhenStorageIsFull()
        {
            FullStorageSetUp();
            Assert.Throws<InvalidOperationException>(() => warehouse.UnloadVehicle(3));
        }
        [Test]
        public void DoesUnloadVehicleUnloadAndReturnCorrectlyWhenStorageIsNotFull()
        {
            var auto = new AutomatedWarehouse("auto");
            var truck = auto.GetVehicle(0);
            truck.LoadProduct(new Gpu(100));
            auto.SendVehicleTo(0, warehouse);
            warehouse.UnloadVehicle(3).Should().Be(1);
            warehouse.IsFull.Should().BeFalse();
        }
    }
}
