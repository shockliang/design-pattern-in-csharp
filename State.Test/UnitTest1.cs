using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State.Coding.Exercise;

namespace State.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSuccess()
        {
            // Arrange

            // Act
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });

            // Assert
            cl.Status.Should().Be("LOCKED");

            cl.EnterDigit(1);
            cl.Status.Should().Be("1");

            cl.EnterDigit(2);
            cl.Status.Should().Be("12");

            cl.EnterDigit(3);
            cl.Status.Should().Be("123");

            cl.EnterDigit(4);
            cl.Status.Should().Be("1234");

            cl.EnterDigit(5);
            cl.Status.Should().Be("OPEN");
        }

        [TestMethod]
        public void TestFailure()
        {
            // Arrange

            // Act
            var cl = new CombinationLock(new[] { 1, 2, 3 });

            // Assert
            cl.Status.Should().Be("LOCKED");

            cl.EnterDigit(1);
            cl.Status.Should().Be("1");

            cl.EnterDigit(2);
            cl.Status.Should().Be("12");
            
            cl.EnterDigit(5);
            cl.Status.Should().Be("ERROR");
        }
    }
}
