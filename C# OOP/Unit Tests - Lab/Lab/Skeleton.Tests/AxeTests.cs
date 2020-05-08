
using System;

namespace Skeleton.Tests
{
    using NUnit.Framework;
    using FluentAssertions;
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void DoesAxeLoseDurability()
        {
            //Arrange
            var axe = new Axe(10,10);
            var dummy = new Dummy(10,10);
            //Act
            axe.Attack(dummy);
            //Assert
            axe.DurabilityPoints.Should().Be(9);
        }

        [Test]
        public void DoesAttackingWithBrokenWeaponThrowException()
        {
            //Arrange
            var axe = new Axe(10,0);
            var dummy = new Dummy(10,10);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(()=> axe.Attack(dummy));
        }
    }
}
