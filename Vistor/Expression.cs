using System;
using System.Collections.Generic;
using System.Text;

namespace Vistor
{
    using DicType = Dictionary<Type, Action<Expression, StringBuilder>>;

    public abstract class Expression
    {

    }

    public static class ExpressionPrinter
    {
        private static DicType actions = new DicType
        {
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.Value);
            },
            [typeof(AdditionExpression)] = (e, sb) =>
            {
                var ae = (AdditionExpression)e;
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append("+");
                Print(ae.Right, sb);
                sb.Append(")");
            }
        };

        public static void Print(Expression e, StringBuilder sb)
        {
            actions[e.GetType()](e, sb);
        }
        // public static void Print(Expression e, StringBuilder sb)
        // {
        //     if (e is DoubleExpression de)
        //     {
        //         sb.Append(de.Value);
        //     }
        //     else if (e is AdditionExpression ae)
        //     {
        //         sb.Append("(");
        //         Print(ae.Left, sb);
        //         sb.Append("+");
        //         Print(ae.Right, sb);
        //         sb.Append(")");
        //     }
        // }
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            this.Value = value;
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression Left;
        public readonly Expression Right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.Left = left ?? throw new System.ArgumentNullException(nameof(left));
            this.Right = right ?? throw new System.ArgumentNullException(nameof(right));
        }
    }
}