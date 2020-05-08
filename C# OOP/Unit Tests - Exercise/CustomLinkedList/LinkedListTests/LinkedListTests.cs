
namespace LinkedListTests
{
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;
    using System;

    using CustomLinkedList;
    using FluentAssertions;

    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void DoesConstructorSetValuesCorrectly()
        {
            var list = new DynamicList<int>();
            list.Count.Should().Be(0);
            var headValue = list.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .First(x => x.Name == "tail")
                .GetValue(list)
                ;
            var tailsValue = list.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .First(x => x.Name == "head")
                .GetValue(list)
                ;
            headValue.Should().BeNull();
            tailsValue.Should().BeNull();
       }
        [Test]
        public void DoesCountReturnRightCount()
        {
            var list = new DynamicList<int>();
            list.Count.Should().Be(0);
        }
        [Test]
        public void DoesIndexatorThrowExceptionWhenIndexIsBelowZero()
        {
            var list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list[-1]++);
        }
        [Test]
        public void DoesIndexatorThrowExceptionWhenIndexIsOverCount()
        {
            var list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list[list.Count]++);
        }
        [Test]
        public void DoesIndexatorReturnValueCorrectly()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list[0].Should().Be(1);
        }
        [Test]
        public void DoesAddingWorkCorrectly()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list[0].Should().Be(1);
            list.Count.Should().Be(1);
        }
        [Test]
        public void DoesRemoveAtThrowExceptionWhenIndexIsBelowZero()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        }
        [Test]
        public void DoesRemoveAtThrowExceptionWhenIndexIsOverCount()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(list.Count));
        }
        [Test]
        public void DoesRemoveAtRemoveCorrectlyAtGivenIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.RemoveAt(0);
            list.Count.Should().Be(0);
        }
        [Test]
        public void DoesRemoveRemoveCorrectlyAGivenElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Remove(1);
            list.Count.Should().Be(0);
        }
        [Test]
        public void DoesRemoveReturnIndexAfterRemoving()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var index = list.Remove(1);
            index.Should().Be(0);
        }
        [Test]
        public void DoesRemoveReturnMinusOneAfterNotFindingRemovedElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var index = list.Remove(5);
            index.Should().Be(-1);
        }
        [Test]
        public void DoesIndexOfReturnMinusOneAfterNotFindingElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var index = list.IndexOf(5);
            index.Should().Be(-1);
        }
        [Test]
        public void DoesIndexOfReturnCorrectIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var index = list.IndexOf(1);
            index.Should().Be(0);
        }
        [Test]
        public void DoesContainsReturnTrueIfFound()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var contains = list.Contains(1);
            contains.Should().Be(true);
        }
        public void DoesContainsReturnFalseIfNotFound()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var contains = list.Contains(5);
            contains.Should().Be(false);
        }
    }
}
