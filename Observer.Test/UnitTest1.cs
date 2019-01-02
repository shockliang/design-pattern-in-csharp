using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer.Coding.Exercise;

namespace Observer.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get_fields_and_properties_should_be_empty()
        {
            // Arrange

            // Act

            // Assert
            typeof(Game).GetFields().Should().BeEmpty();
            typeof(Game).GetProperties().Should().BeEmpty();
        }

        [TestMethod]
        public void Single_rat_join_the_game_the_rat_attack_should_be_1()
        {
            // Arrange
            var game = new Game();

            // Act
            var rat = new Rat(game);

            // Assert
            rat.Attack.Should().Be(1);
        }

        [TestMethod]
        public void Two_rats_join_the_game_the_rats_attack_should_be_2()
        {
            // Arrange
            var game = new Game();

            // Act
            var rat = new Rat(game);
            var rat2 = new Rat(game);

            // Assert
            rat.Attack.Should().Be(2);
            rat2.Attack.Should().Be(2);
        }

        [TestMethod]
        public void Three_rats_join_the_game_and_one_dead_the_final_attack_Should_be_2()
        {
            // Arrange
            var game = new Game();

            var rat = new Rat(game);
            rat.Attack.Should().Be(1);

            // Act
            var rat2 = new Rat(game);

            // Assert
            rat.Attack.Should().Be(2);
            rat2.Attack.Should().Be(2);

            // Act
            using (var rat3 = new Rat(game))
            {
                // Assert
                rat.Attack.Should().Be(3);
                rat2.Attack.Should().Be(3);
                rat3.Attack.Should().Be(3);
            }

            // Assert 
            rat.Attack.Should().Be(2);
            rat2.Attack.Should().Be(2);
        }
    }
}
