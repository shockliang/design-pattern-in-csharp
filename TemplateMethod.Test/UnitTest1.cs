using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateMethod.Coding.Exercise;

namespace TemplateMethod.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ImpasseTest()
        {
            // Arrange
            var c1 = new Creature(attack: 1, health: 2);
            var c2 = new Creature(attack: 1, health: 2);

            // Act
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });

            // Assert
            game.Combat(creature1: 0, creature2: 1).Should().Be(-1);
            game.Combat(creature1: 0, creature2: 1).Should().Be(-1);
        }

        [TestMethod]
        public void TemporaryMurderTest()
        {
            // Arrange
            var c1 = new Creature(attack: 1, health: 1);
            var c2 = new Creature(attack: 2, health: 2);

            // Act
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });

            // Assert
            game.Combat(creature1: 0, creature2: 1).Should().Be(1);
        }

        [TestMethod]
        public void DoubleMurderTest()
        {
            // Arrange
            var c1 = new Creature(attack: 2, health: 2);
            var c2 = new Creature(attack: 2, health: 2);

            // Act
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });

            // Assert
            game.Combat(0, 1).Should().Be(-1);
        }

        [TestMethod]
        public void PermanentDamageDeathTest()
        {
            // Arrange
            var c1 = new Creature(attack: 1, health: 2);
            var c2 = new Creature(attack: 1, health: 3);
            
            // Act
            CardGame game = new PermanentCardDamage(new[] { c1, c2 });

            // Assert
            game.Combat(0, 1).Should().Be(-1);
            game.Combat(0, 1).Should().Be(1);
        }
    }
}
