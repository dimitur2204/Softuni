using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aqua;
        private Fish dummyFish;
        [SetUp]
        public void SetUp()
        {
            aqua = new Aquarium("Dummy", 50);
            dummyFish = new Fish("Dummy");
        }
        [Test]
        public void FishShouldInitializeSuccessfully()
        {
            var fish = new Fish("Dummy");
            Assert.AreEqual("Dummy",fish.Name);
            Assert.IsTrue(fish.Available);
        }
        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void AquariumShouldThrowExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => { new Aquarium(name, 1); });
        }
        [Test]
        public void AquariumShouldInitializeAndReturnNameProperly()
        {
            Assert.AreEqual("Dummy",aqua.Name);
        }
        [TestCase(-1)]
        [TestCase(-50)]
        [Test]
        public void AquariumShouldThrowExceptionWhenCapacityIsLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => { new Aquarium("Dummy", capacity); });
        }
        [Test]
        public void AquariumShouldInitializeAndReturnCapacityProperly()
        {
            Assert.AreEqual(50, aqua.Capacity);
        }
        [Test]
        public void AquariumShouldThrowExceptionWhenAddFishIsCalledOnFullCap()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var noCapAqua = new Aquarium("NoCap",0);
                noCapAqua.Add(dummyFish);
            });
        }
        [Test]
        public void AquariumShouldAddFishCorrectly()
        {
            aqua.Add(dummyFish);
            Assert.AreEqual(1,aqua.Count);
        }
        [Test]
        public void AquariumShouldThrowExceptionWhenRemoveFishIsCalledOnNonExistingFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var noCapAqua = new Aquarium("NoCap", 0);
                noCapAqua.RemoveFish("NoSuchFish");
            });
        }
        [Test]
        public void AquariumShouldRemoveFishIsCalledOnExistingFish()
        {
            aqua.Add(dummyFish);
            Assert.AreEqual(1, aqua.Count);
            aqua.RemoveFish("Dummy");
            Assert.AreEqual(0, aqua.Count);
        }
        [Test]
        public void AquariumShouldThrowExceptionWhenSellFishIsCalledOnNonExistingFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var noCapAqua = new Aquarium("NoCap", 0);
                noCapAqua.SellFish("NoSuchFish");
            });
        }
        [Test]
        public void AquariumShouldSellFishIsCalledOnExistingFish()
        {
            aqua.Add(dummyFish);
            Assert.AreEqual(1, aqua.Count);
            var returnedFish = aqua.SellFish("Dummy");
            Assert.IsFalse(dummyFish.Available);
            Assert.AreSame(this.dummyFish, returnedFish);
        }
        [Test]
        public void ReportShouldReturnCorrectValues()
        {
            aqua.Add(dummyFish);
            aqua.Add(new Fish("NewFish"));
            var expected = $"Fish available at Dummy: Dummy, NewFish";
            Assert.AreEqual(expected,aqua.Report());
        }
    }
}
