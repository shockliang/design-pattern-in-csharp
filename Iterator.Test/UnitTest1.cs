using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Node = Iterator.Coding.Exercise.Node<char>;

namespace Iterator.Test
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Passing_char_nodes_should_as_expected()
        {
            // Arrange
            var node = new Node('a',
                    new Node('b',
                        new Node('c'),
                        new Node('d')),
                    new Node('e'));

            // Act
            var actual =  new string(node.PreOrder.ToArray());

            // Assert
            actual.Should().Be("abcde");
        }
    }
}
