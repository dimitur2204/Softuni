using System;
using System.Linq;

namespace Computers.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ComputerTests
    {
        private Computer computer;
        private Part part;
        [SetUp]
        public void SetUp()
        {
            this.computer = new Computer("Dummy");
            this.part = new Part("DummyPart",10);

        }

        [Test]
        public void ConstructorShouldInitializePartProperly()
        {
            Assert.AreEqual("DummyPart",this.part.Name);
            Assert.AreEqual(10m,this.part.Price);
        }
        [Test]
        public void ConstructorShouldInitializeComputerProperly()
        {
            Assert.AreEqual("Dummy", this.computer.Name);
            Assert.IsNotNull(this.computer.Parts);
        }
        [Test]
        public void ComputerShouldThrowErrorWhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>((() => { new Computer(""); }));
        }
        [Test]
        public void AddPartShouldThrowErrorWhenPartIsNull()
        {
            Assert.Throws<InvalidOperationException>((() => { this.computer.AddPart(null);}));
        }
        [Test]
        public void AddPartShouldAddPartWhenIsNotNull()
        {
           this.computer.AddPart(this.part);
           Assert.AreSame(this.part,this.computer.Parts.First());
        }
        [Test]
        public void TotalPriceShouldReturnPriceOfAllParts()
        {
            this.computer.AddPart(this.part);
            Assert.AreEqual(10m, this.computer.TotalPrice);
        }
        [Test]
        public void RemovePartShouldReturnFalseWhenPartIsNotFound()
        {
            Assert.IsFalse(this.computer.RemovePart(this.part));
        }
        [Test]
        public void RemovePartShouldReturnTrueAndRemoveWhenPartIsFound()
        {
            this.computer.AddPart(this.part);
            Assert.IsTrue(this.computer.RemovePart(this.part));
            Assert.AreEqual(0,this.computer.Parts.Count);
        }
        [Test]
        public void GetPartShouldReturnNullWhenPartIsNotFound()
        {
            Assert.IsNull(this.computer.GetPart("NoSuchPart"));
        }
        [Test]
        public void GetPartShouldReturnPartWhenPartIsFound()
        {
            this.computer.AddPart(this.part);
            Assert.AreSame(this.part,this.computer.GetPart("DummyPart"));
        }
    }
}