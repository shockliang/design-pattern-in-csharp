using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using Singleton;

namespace Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }

        [Test]
        public void ConfigurableRecordFinderTest()
        {
            // Arrange
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gamma" };

            // Act
            var resutl = rf.GetTotalPopulation(names);

            // Assert
            Assert.That(resutl, Is.EqualTo(4));
        }

        [Test]
        public void DependencyInjectionPopulationTest()
        {
            // Arrange
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();

            // Act
            using(var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
            }

            // Assert
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }
}