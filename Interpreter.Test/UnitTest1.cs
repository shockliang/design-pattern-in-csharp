using System;
using FluentAssertions;
using Interpreter.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interpreter.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Calculate_1_plus_2_should_be_3()
        {
            // Arrange
            var target = new ExpressionProcessor();

            // Act
            var result = target.Calculate("1+2");

            // Assert
            result.Should().Be(3);
        }

        [TestMethod]
        public void Calculate_1_plus_2_plus_3_should_be_6()
        {
            // Arrange
            var target = new ExpressionProcessor();

            // Act
            var result = target.Calculate("1+2+3");

            // Assert
            result.Should().Be(6);
        }

        [TestMethod]
        public void Calculate_123_plus_456_plus_789_should_be_1368()
        {
            // Arrange
            var target = new ExpressionProcessor();

            // Act
            var result = target.Calculate("123+456+789");

            // Assert
            result.Should().Be(1368);
        }

        [TestMethod]
        public void Calculate_1_plus_2_plus_xy_should_be_0_cause_xy_not_legal()
        {
            // Arrange
            var target = new ExpressionProcessor();

            // Act
            var result = target.Calculate("1+2+xy");

            // Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void Calculate_only_x_variable_should_be_3_when_x_equals_to_3()
        {
            // Arrange
            var target = new ExpressionProcessor();
            target.Variables.Add('x', 3);

            // Act
            var result = target.Calculate("x");

            // Assert
            result.Should().Be(3);
        }

        [TestMethod]
        public void Calculate_10_minus_x_variable_should_be_7_when_x_equals_to_3()
        {
            // Arrange
            var target = new ExpressionProcessor();
            target.Variables.Add('x', 3);

            // Act
            var result = target.Calculate("10-x");

            // Assert
            result.Should().Be(7);
        }

        [TestMethod]
        public void Calculate_10_minus_2_minus_x_variable_should_be_5_when_x_equals_to_3()
        {
            // Arrange
            var target = new ExpressionProcessor();
            target.Variables.Add('x', 3);

            // Act
            var result = target.Calculate("10-2-x");

            // Assert
            result.Should().Be(5);
        }

        [TestMethod]
        public void Calculate_10_minus_2_minus_x_variable_should_be_0_when_x_not_exist_in_variables()
        {
            // Arrange
            var target = new ExpressionProcessor();

            // Act
            var result = target.Calculate("10-2-x");

            // Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void Calculate_10_minus_x_minus_2_variable_should_be_5_when_x_equals_to_3()
        {
            // Arrange
            var target = new ExpressionProcessor();
            target.Variables.Add('x', 3);

            // Act
            var result = target.Calculate("10-x-2");

            // Assert
            result.Should().Be(5);
        }
    }
}
