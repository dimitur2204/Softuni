using NUnit.Framework;

namespace Presents.Tests
{
    [TestFixture]
    public class PresentsTests
    {

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(-0.5)]
        [TestCase(1.5)]
        [Test]
        public void PresentConstructorShouldSetValuesCorrectly(double magic)
        {
            var present = new Present("Dummy",magic);
            Assert.AreEqual("Dummy",present.Name);
            Assert.AreEqual(magic,present.Magic);
        }
    }
}
