using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vistor.Coding.Exercise;

namespace Vistor.Test
{
    using AdditionExpression = Vistor.Coding.Exercise.AdditionExpression;
    using ExpressionPrinter = Vistor.Coding.Exercise.ExpressionPrinter;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleAddition()
        {
            // Arrange
            var simple = new AdditionExpression(new Value(2), new Value(3));
            var ep = new ExpressionPrinter();

            // Act
            ep.Visit(simple);

            // Assert
            ep.ToString().Should().Be("(2+3)");
        }

        [TestMethod]
        public void ProductOfAdditionAndValue()
        {
            // Arrange
            var expr = new MultiplicationExpression(
              new AdditionExpression(new Value(2), new Value(3)),
              new Value(4)
              );
            var ep = new ExpressionPrinter();

            // Act
            ep.Visit(expr);

            // Assert
            ep.ToString().Should().Be("(2+3)*4");
        }
    }
}
