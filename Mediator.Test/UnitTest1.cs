using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mediator.Coding.Exercise;
using FluentAssertions;

namespace Mediator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Both_initial_value_should_be_0()
        {
            // Arrange 
            var mediator = new Mediator.Coding.Exercise.Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);

            // Act

            // Assert
            p1.Value.Should().Be(0);
            p2.Value.Should().Be(0);
        }
        
        [TestMethod]
        public void P1_broadcast_value_2_the_p2_should_be_2_and_self_should_be_0()
        {
            // Arrange 
            var mediator = new Mediator.Coding.Exercise.Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);

            // Act
            p1.Say(2);

            // Assert
            p1.Value.Should().Be(0);
            p2.Value.Should().Be(2);
        }

        [TestMethod]
        public void Broadcast_values_to_each_other_the_values_should_as_expected()
        {
            // Arrange 
            var mediator = new Mediator.Coding.Exercise.Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);

            // Act
            p1.Say(2);
            p2.Say(4);

            // Assert
            p1.Value.Should().Be(4);
            p2.Value.Should().Be(2);
        }
    }
}
