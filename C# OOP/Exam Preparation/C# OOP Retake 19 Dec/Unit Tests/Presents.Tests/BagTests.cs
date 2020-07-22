
using System;
using NUnit.Framework;

namespace Presents.Tests
{
    [TestFixture]
    public class BagTests
    {
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }

        [Test]
        public void BagCreateShouldThrowExceptionWhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }
        [Test]
        public void BagCreateShouldThrowExceptionWhenPresentExists()
        {
            var present = new Present("dummy", 1);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void BagCreateShouldAddPresentCorrectly()
        {
            var present = new Present("dummy", 1);
            bag.Create(present);
            Assert.AreEqual(present, bag.GetPresent("dummy"));
        }
        [Test]
        public void BagCreateShouldRemovePresentCorrectly()
        {
            var present = new Present("dummy", 1);
            bag.Create(present);
            var removed = bag.Remove(present);
            Assert.AreEqual(0, bag.GetPresents().Count);
            Assert.IsTrue(removed);
        }
        [Test]
        public void BagCreateShouldReturnFalseWhenRemovePresentDoesNotExist()
        {
            var present = new Present("dummy", 1);
            var removed = bag.Remove(present);
            Assert.IsFalse(removed);
        }

        [Test]
        public void BagGetPresentWithLeastMagicShouldReturnCorrectly()
        {
            var present = new Present("dummy", 1);
            bag.Create(present);
            Assert.AreEqual(present,bag.GetPresentWithLeastMagic());
        }
    }
}
