
namespace Skeleton.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    [TestFixture]
    class DummyTests
    {
        [Test]
        public void DoesDummyLoseHealthWhenAttacked()
        {
            //Arrange
            var dummy = new Dummy(10,10);
            //Act
            dummy.TakeAttack(5);
            //Assert
            dummy.Health.Should().Be(5);
        }

        [Test]
        public void DoesDeadDummyThrowExceptionWhenAttacked()
        {
            //Arrange
            var dummy = new Dummy(0,10);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }

        [Test]
        public void DoesDeadDummyGiveExperience()
        {
            var dummy = new Dummy(0,10);
            var experience = dummy.GiveExperience();
            experience.Should().Be(10);
        }

        [Test]
        public void DoesAliveDummyThrowExceptionWhenGivingExperience()
        {
            var dummy = new Dummy(10,10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
