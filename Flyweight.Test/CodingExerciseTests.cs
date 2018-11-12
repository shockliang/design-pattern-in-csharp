using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Flyweight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flyweight.Test
{
    [TestClass]
    public class CodingExerciseTests
    {
        [TestMethod]
        public void CodingExerciseTest()
        {
            // Arrange
            var sentence = new Sentence("hello world");
        
            // Act
            sentence[1].Capitalize = true;
        
            // Assert
            Assert.AreEqual("hello WORLD", sentence.ToString());
        }
        
    }
}