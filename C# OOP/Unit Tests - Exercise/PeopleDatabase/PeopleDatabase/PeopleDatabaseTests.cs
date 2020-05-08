

namespace PeopleDatabaseTest
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    using PeopleDatabase;
    using FluentAssertions;

    public class PeopleDatabaseTests
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void DoesDefaultConstructorInitiateListProperly()
        {
            var db = new PeopleDatabase();
            db.People.Should().NotBeNull();
        }
        [Test]
        public void DoesConstructorWithPeopleInitiateProperly()
        {
            var man = new Man(1,"Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            db.Count().Should().Be(1);
        }
        [Test]
        public void DoesAddingThrowExceptionCorrectlyWhenAddingAnExistingID()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Man(1,"Marshala")));
        }
        [Test]
        public void DoesAddingThrowExceptionCorrectlyWhenAddingAnExistingUsername()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Man(2, "Marshal")));
        }
        [Test]
        public void DoesAddingWorkCorrectlyWhenAddingAPerson()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            var anotherMan = new Man(2, "Marshalll");
            db.Add(anotherMan);
            db.Count().Should().Be(2);
        }
        [Test]
        public void DoesRemoveThrowExceptionWhenRemovingFromEmpty()
        {
            var db = new PeopleDatabase();
            Assert.Throws<InvalidOperationException>(() => db.Remove(new Man(1, "Marshal")));
        }
        [Test]
        public void DoesRemoveWorkCorrectlyWhenRemoving()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            db.Remove(man);
            db.Count().Should().Be(0);
        }
        [Test]
        public void DoesFindByIDThrowExceptionWhenIDIsNegative()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }
        [Test]
        public void DoesFindByIDThrowExceptionWhenIDIsNotPresent()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }
        [Test]
        public void DoesFindByIDReturnCorrectlyWhenIDIsPresent()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            man.Should().BeSameAs(db.FindById(1));
        }
        [Test]
        public void DoesFindByUsernameThrowExceptionWhenPersonIsNotPresent()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Marshalll"));
        }
        [Test]
        public void DoesFindByUsernameThrowExceptionWhenUsernameGivenIsNULL()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }
        [Test]
        public void DoesFindByUsernameReturnCorrectlyWhenUsernameIsPresent()
        {
            var man = new Man(1, "Marshal");
            var people = new List<Man>();
            people.Add(man);
            var db = new PeopleDatabase(people);
            man.Should().BeSameAs(db.FindByUsername("Marshal"));
        }
    }
}
