using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.Coding.Exercise
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public int Value { get; }

        public Integer(int value)
        {
            this.Value = value;
        }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition, Substraction
        }

        public Type MyType;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (MyType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Substraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class Token
    {
        public enum Type
        {
            Integer,
            Plus,
            Minus,
            Variable,
            Illegal
        }

        public Type MyType;

        public string Text;

        public Token(Type myType, string text)
        {
            MyType = myType;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var tokens = LexHelper.Lex(expression);
            var op = new BinaryOperation();
            var current = new Integer(0);

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        current = new Integer(int.Parse(token.Text));
                        
                        if (i == 0 && tokens.Count > 1)
                        {
                            op.Left = current;
                        }
                        else if (tokens.Count == 1)
                        {
                            return current.Value;
                        }
                        else
                        {
                            op.Right = current;
                            if (i < tokens.Count - 1)
                                op.Left = new Integer(op.Value);
                        }
                        break;
                    case Token.Type.Plus:
                        op.MyType = BinaryOperation.Type.Addition;

                        break;
                    case Token.Type.Minus:
                        op.MyType = BinaryOperation.Type.Substraction;
                        break;
                    case Token.Type.Variable:
                        var keyOfVar = token.Text.FirstOrDefault();
                        if (!Variables.ContainsKey(keyOfVar)) return 0;

                        current = new Integer(Variables[keyOfVar]);

                        if (i == 0 && tokens.Count > 1)
                        {
                            op.Left = current;
                        }
                        else if (tokens.Count == 1)
                        {
                            return current.Value;
                        }
                        else
                        {
                            op.Right = current;
                            if (i < tokens.Count - 1)
                                op.Left = new Integer(op.Value);
                        }

                        break;
                    case Token.Type.Illegal:
                        return 0;
                }
            }
            return op.Value;
        }
    }

    public class LexHelper
    {
        public static List<Token> Lex(string input)
        {
            var result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    default:
                        var section = new string(input
                            .Skip(i)
                            .TakeWhile(c => c != '+' && c != '-')
                            .ToArray());

                        if (int.TryParse(section, out int val))
                        {
                            result.Add(new Token(Token.Type.Integer, section));
                        }
                        else
                        {
                            if (section.Count() >= 2)
                                result.Add(new Token(Token.Type.Illegal, section));
                            else if (section.Count() == 1)
                                result.Add(new Token(Token.Type.Variable, section));
                        }

                        if (section.Count() > 1)
                            i += section.Count() - 1;

                        break;
                }
            }

            return result;
        }
    }
}
