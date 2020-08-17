using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private Computer dummyComputer;
        private ComputerManager dummyManager;
        [SetUp]
        public void Setup()
        {
            dummyComputer = new Computer("DummyMan","DummyMod",10.1m);
            dummyManager = new ComputerManager();
        }

        [Test]
        public void ComputerShouldInstantiateManProperly()
        {
            Assert.AreEqual("DummyMan",dummyComputer.Manufacturer);
        }
        [Test]
        public void ComputerShouldInstantiateModProperly()
        {
            Assert.AreEqual("DummyMod", dummyComputer.Model);
        }
        [Test]
        public void ComputerShouldInstantiatePriceProperly()
        {
            Assert.AreEqual(10.1m, dummyComputer.Price);
        }
        [Test]
        public void ComputerManagerShouldInstantiateComputersProperly()
        {
            Assert.IsNotNull(dummyManager.Computers);
            Assert.AreEqual(0,dummyManager.Count);
        }
        [Test]
        public void AddComputerShouldThrowExceptionWhenGivenNull()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.AddComputer(null); });
        }
        [Test]
        public void AddComputerShouldNotAddComputerWhenGivenNull()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.AddComputer(null); });
            Assert.AreEqual(0,dummyManager.Count);
        }
        [Test]
        public void AddComputerShouldAddProperlyWhenNotNull()
        {
            var comp = new Computer("Man", "Mod", 10.5m);
            dummyManager.AddComputer(comp);
            Assert.AreEqual(1, dummyManager.Count);
            Assert.AreSame(comp, dummyManager.Computers.First());
        }
        [Test]
        public void AddComputerShouldThrowExceptionWhenThereIsSuchComputer()
        {
            var comp = new Computer("Man", "Mod", 10.5m);
            dummyManager.AddComputer(comp);
            Assert.Throws<ArgumentException>(() => { dummyManager.AddComputer(comp); });
        }
        [Test]
        public void AddComputerShouldNotAddWhenGivenExisting()
        {
            var comp = new Computer("Man", "Mod", 10.5m);
            dummyManager.AddComputer(comp);
            Assert.Throws<ArgumentException>(() => { dummyManager.AddComputer(comp); });
            Assert.AreEqual(1, dummyManager.Count);
        }
        [Test]
        public void CountShouldReturnCountProperly()
        {
            Assert.AreEqual(0,dummyManager.Count);
            dummyManager.AddComputer(dummyComputer);
            Assert.AreEqual(1, dummyManager.Count);
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenGivenNullForManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.GetComputer(null,"Model"); });
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenGivenNullForModel()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.GetComputer("Manufacturer", null); });
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenGivenNullForBoth()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.GetComputer(null, null); });
        }
        [Test]
        public void GetComputerShouldThrowExceptionWhenGivenThereIsNoComputerWithThatModelAndManufacturer()
        {
            Assert.Throws<ArgumentException>(() => { dummyManager.GetComputer("NoSuchManufacturer", "NoSuchModel"); });
        }
        [Test]
        public void GetComputerShouldReturnComputerCorrectly()
        {
            dummyManager.AddComputer(dummyComputer); 
            Assert.AreSame(dummyComputer, dummyManager.GetComputer("DummyMan", "DummyMod"));
            Assert.AreSame(dummyComputer.Manufacturer, dummyManager.GetComputer("DummyMan", "DummyMod").Manufacturer);
        }
        [Test]
        public void RemoveComputerShouldThrowExceptionWhenThereIsNoSuchComp()
        {
            dummyManager.AddComputer(dummyComputer);
            Assert.Throws<ArgumentException>(() => { var comp = dummyManager.RemoveComputer("", ""); });
            Assert.AreEqual(1, dummyManager.Count);
        }
        [Test]
        public void RemoveComputerShouldThrowExceptionWhenGivenNullForMan()
        {
            dummyManager.AddComputer(dummyComputer);
            Assert.Throws<ArgumentNullException>(() => { var comp = dummyManager.RemoveComputer(null, ""); });
            Assert.AreEqual(1, dummyManager.Count);
        }
        [Test]
        public void RemoveComputerShouldThrowExceptionWhenGivenNullForMod()
        {
            dummyManager.AddComputer(dummyComputer);
            Assert.Throws<ArgumentNullException>(() => { var comp = dummyManager.RemoveComputer("", null); });
            Assert.AreEqual(1, dummyManager.Count);
        }

        [Test]
        public void RemoveComputerShouldRemoveComputerCorrectly()
        {
            dummyManager.AddComputer(dummyComputer);
            var comp = dummyManager.RemoveComputer("DummyMan", "DummyMod");
            Assert.AreEqual(0, dummyManager.Count);
        }
        [Test]
        public void RemoveComputerShouldReturnComputerCorrectly()
        {
            dummyManager.AddComputer(dummyComputer);
            var comp = dummyManager.RemoveComputer("DummyMan", "DummyMod");
            Assert.AreSame(dummyComputer, comp);
        }
        [Test]
        public void GetComputersByManufacturerShouldThrowExceptionWhenGivenNull()
        {
            Assert.Throws<ArgumentNullException>(() => { dummyManager.GetComputersByManufacturer(null);});
        }
        [Test]
        public void GetComputersByManufacturerShouldReturnCorrectCollection()
        {
            dummyManager.AddComputer(dummyComputer);
            var comps = dummyManager.GetComputersByManufacturer("DummyMan");
            Assert.IsInstanceOf<ICollection<Computer>>(comps);
            Assert.AreSame(dummyComputer,comps.First());
        }
        [Test]
        public void GetComputersByManufacturerShouldReturn0WhenNoComputersAreOfThisMan()
        {
            dummyManager.AddComputer(dummyComputer);
            dummyManager.AddComputer(new Computer("DummyMan", "Model", 10.5m));
            var comps = dummyManager.GetComputersByManufacturer("AnotherMan");
            Assert.IsNotNull(comps);
            Assert.AreEqual(0, comps.Count);
        }
        [Test]
        public void GetComputersByManufacturerShouldReturnCollection()
        {
            dummyManager.AddComputer(dummyComputer);
            dummyManager.AddComputer(new Computer("DummyMan","Model",10.5m));
            var comps = dummyManager.GetComputersByManufacturer("DummyMan");
            Assert.IsNotNull(comps);
            Assert.AreEqual(2,comps.Count);
        }
        [Test]
        public void ValidateNotNullShouldThrowExceptionWhenGivenNull()
        {
            var validateNullMethod = dummyManager.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(m => m.Name == "ValidateNullValue");
            var parameters = new object[]
            {
                null, 
                "message", 
                "null" 
            };
            Assert.Throws<TargetInvocationException>(() =>
            {
                validateNullMethod.Invoke(new ComputerManager(), parameters);
            });
        }
    }
}