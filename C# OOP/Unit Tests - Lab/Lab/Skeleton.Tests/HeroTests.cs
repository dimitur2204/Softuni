using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    class HeroTests
    {
        [Test]
        public void DoesHeroGainXPWhenTargetDies()
        {
            //Arrange
            var dummy = new Mock<Dummy>(10,10);
            var hero = new Mock<Hero>("Batman");
            dummy.Object.TakeAttack(hero.Object.Weapon.AttackPoints);
            var experience = dummy.Object.GiveExperience();
            experience.Should().Be(10);
        }
    }
}
