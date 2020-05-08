namespace StorageMasterTests
{
    using NUnit.Framework;
    using System;
    using FluentAssertions;

    using StorageMaster.Entities.Factories;
    using StorageMaster.Entities.Vehicles;

    [TestFixture]
    public class VehicleFactoryTests
    {
        private VehicleFactory vehicleFactory = new VehicleFactory();
        [Test]
        public void DoesCreateVehicleMethodThrowExceptionWhenInvalidVehicleIsGiven()
        {
            Assert.Throws<InvalidOperationException>(() => vehicleFactory.CreateVehicle("NoSuchVehicle"));
        }
        [Test]
        public void DoesCreateVehicleMethodCreateVehicleSuccesfully()
        {
            var warehouse = vehicleFactory.CreateVehicle("Semi");
            warehouse.Should().BeOfType(typeof(Semi));
        }
    }
}