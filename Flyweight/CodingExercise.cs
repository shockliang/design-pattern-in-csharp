using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Sentence
    {
        private readonly string plainText;
        private List<WordToken> wordTokens;

        public Sentence(string plainText)
        {
            this.plainText = plainText;
            wordTokens = plainText.Split(" ")
                .Select(word => new WordToken(word))
                .ToList();
        }

        public WordToken this[int index] => wordTokens[index];

        public override string ToString()
        {
            return string.Join(" ", wordTokens.Select(x => x.ToString()).ToArray());
        }

        public class WordToken
        {
            public bool Capitalize;
            private readonly string word;
            public WordToken(string word)
            {
                this.word = word;
            }

            public override string ToString()
            {
                return Capitalize ? word.ToUpper() : word;
            }
        }
    }
}