using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Flyweight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flyweight.Test
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestUser()
        {
            var firstNames = Enumerable.Range(0, 100).Select(i => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(i => RandomString());

            var users = new List<User>();
            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User($"{firstName} {lastName}"));
                }
            }

            ForceGC();
            
            // 410344 bytes
            var size = GetMemorySize(users);

            Console.WriteLine($"users sieze: {size}");
        }

        [TestMethod]
        public void TestUser2()
        {
            var firstNames = Enumerable.Range(0, 100).Select(i => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(i => RandomString());

            var users = new List<User2>();
            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User2($"{firstName} {lastName}"));
                }
            }

            ForceGC();
            
            // 370346 bytes
            var size = GetMemorySize(users);

            Console.WriteLine($"users sieze: {size}");
        }

        private long GetMemorySize(object obj)
        {
            long size = 0;

            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, obj);
                size = s.Length;
            }

            return size;
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            var rand = new Random();
            return new string(
                Enumerable.Range(0, 10)
                    .Select(i => (char)('a' + rand.Next(26)))
                    .ToArray());
        }
    }
}