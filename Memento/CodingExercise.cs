using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Memento.Coding.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        private List<Token> tokens;

        public IReadOnlyCollection<Token> Tokens { get => tokens.AsReadOnly(); }

        public Memento(List<Token> tokens)
        {
            this.tokens = tokens
                .Select(t => new Token(t.Value))
                .ToList();
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));

            return new Memento(new List<Token>(Tokens));
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return new Memento(new List<Token>(Tokens));
        }

        public void Revert(Memento m)
        {
            Tokens.Clear();
            Tokens.AddRange(m.Tokens);
        }
    }
}
