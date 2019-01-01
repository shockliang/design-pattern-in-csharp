using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Memento.Coding.Exercise;
using System;

namespace Memento.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void The_TokenMachine_count_and_first_token_should_as_expected_after_revert()
        {
            // Arrange
            var tm = new TokenMachine();
            var m = tm.AddToken(123);

            // Act
            tm.AddToken(456);
            tm.Revert(m);

            // Assert
            tm.Tokens.Count.Should().Be(1);
            tm.Tokens[0].Value.Should().Be(123);
        }

        [TestMethod]
        public void Two_tokens_value_should_as_expected_after_revert()
        {
            // Arrange
            var tm = new TokenMachine();
            tm.AddToken(1);
            var m = tm.AddToken(2);
            tm.AddToken(3);

            // Act
            tm.Revert(m);

            // Assert
            tm.Tokens.Count.Should().Be(2);
            tm.Tokens[0].Value.Should().Be(1);
            tm.Tokens[1].Value.Should().Be(2);
        }

        [TestMethod]
        public void TestMethod()
        {
            // Arrange
            var tm = new TokenMachine();
            // Console.WriteLine("Made a token with value 111 and kept a reference"); 
            var token = new Token(111);
            // Console.WriteLine("Added this token to the list");

            tm.AddToken(token);
            var m = tm.AddToken(222);
            token.Value = 333;
            // Console.WriteLine("Changed this token's value to 333 :)");

            // Act
            tm.Revert(m);

            // Assert
            tm.Tokens.Count.Should().Be(2);
            tm.Tokens[0].Value.Should().Be(111);
        }
    }
}
