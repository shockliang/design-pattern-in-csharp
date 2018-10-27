using System;
using NUnit.Framework;

namespace Singleton.Test
{
    public class SingletonTesterTests
    {
        [Test]
        public void IsSingletonTest()
        {
            // Arrange 

            // Act
            var actual = SingletonTester.IsSingleton(() => SingletonDatabase.Instance);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}