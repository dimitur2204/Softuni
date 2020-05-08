
    using NUnit.Framework;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;


    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }
        [Test]
        public void DoesConstructorSetIntegersCorrectlyWhenInitiatedWithLessThan16()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                numbers.Add(i);
            }
            var db = new Database(numbers);
            db.Fetch().Length.Should().Be(5);
        }

        [Test]
        public void DoesConstructorThrowExceptionWhenInitiatedWithMoreThan16()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 17; i++)
            {
                numbers.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => new Database(numbers));
        }
        [Test]
        public void DoesAddMethodAddNumbersCorrectly()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                numbers.Add(i);
            }
            var db = new Database(numbers);
            db.Add(5);
            db.Fetch().Length.Should().Be(6);
        }
        [Test]
        public void DoesAddMethodThrowExceptionWhenExceedingLimit()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 16; i++)
            {
                numbers.Add(i);
            }
            var db = new Database(numbers);
            Assert.Throws<InvalidOperationException>(() => db.Add(5));
        }

        [Test]
        public void DoesRemoveWorkCorrectlyWhenUsedOnANonEmptyDb()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 16; i++)
            {
                numbers.Add(i);
            }
            var db = new Database(numbers);
            db.Remove(5);
            db.Fetch().Length.Should().Be(15);
        }

        [Test]
        public void DoesRemoveThrowExceptionCorrectlyWhenUsedOnEmptyList()
        {
            var numbers = new List<int>();
            numbers.Add(1);
            var db = new Database(numbers);
            db.Remove(1);
            Assert.Throws<InvalidOperationException>(() => db.Remove(1));
        }

        [Test]
        public void DoesFetchReturnArrayCorrectly()
        {
            var numbers = new List<int>();
            for (int i = 1; i <= 16; i++)
            {
                numbers.Add(i);
            }
            var db = new Database(numbers);
            db.Fetch().Should().BeEquivalentTo(numbers.ToArray());
        }
    }
