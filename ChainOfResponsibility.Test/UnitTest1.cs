using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChainOfResponsibility.Coding.Exercise;
using FluentAssertions;
using System.Collections.Generic;

namespace ChainOfResponsibility.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void The_goblin_origin_attack_should_be_1_and_defense_should_be_1_when_only_1_goblin()
        {
            // Arrange
            var game = new ChainOfResponsibility.Coding.Exercise.Game();
            var goblin = new Goblin(game);

            // Act
            game.Creatures.Add(goblin);

            // Assert
            goblin.Attack.Should().Be(1);
            goblin.Defense.Should().Be(1);
        }

        [TestMethod]
        public void ManyGoblinsTest()
        {
            var game = new ChainOfResponsibility.Coding.Exercise.Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);

            int attack = goblin.Attack;
            int defense = goblin.Defense;
            attack.Should().Be(1);
            defense.Should().Be(1);

            var goblin2 = new Goblin(game);
            game.Creatures.Add(goblin2);

            goblin.Attack.Should().Be(1);
            goblin.Defense.Should().Be(2);

            var goblinKing = new GoblinKing(game);
            game.Creatures.Add(goblinKing);

            goblin.Attack.Should().Be(2);
            goblin.Defense.Should().Be(3);
        }
    }
}
