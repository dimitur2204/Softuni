
namespace StorageMasterTests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;

    using StorageMaster.Core;
    using StorageMaster.Core.IO;
    using StorageMaster.Core.IO.Contracts;

    [TestFixture]
    public class EngineTests
    {
        private static IReader reader = new ConsoleReader();
        private static IWriter writer = new ConsoleWriter();
        private Engine engine;
        [SetUp]
        public void SetUp()
        {
            this.engine = new Engine(reader,writer);
        }
        [Test]
        public void DoesConstructorSetReaderWriterAndStorageCorrectly()
        {
            var fields = this.engine
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var readerField = fields
                .First(x => x.Name == "reader")
                .GetValue(this.engine);
            var writerField = fields
                .First(x => x.Name == "writer")
                .GetValue(engine);
            var storageMasterField = fields
                .First(x => x.Name == "storageMaster")
                .GetValue(this.engine);
            readerField.Should().NotBeNull();
            writerField.Should().NotBeNull();
            storageMasterField.Should().NotBeNull();
        }
        [Test]
        public void DoesProcessCommandMethodProcessCorrectly()
        {
            var proccessMethod = engine
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
                .First(x => x.Name == "ProcessCommand")
                .ReturnType
                .Name;
            proccessMethod.Should().Be("String");
        }
    }
}
