using System;
using System.Collections.Generic;
using System.Text;

namespace Vistor
{

    // public abstract class Expression
    // {

    // }

    // public class DoubleExpression : Expression
    // {
    //     public double Value;

    //     public DoubleExpression(double value)
    //     {
    //         this.Value = value;
    //     }
    // }

    // public class AdditionExpression : Expression
    // {
    //     public readonly Expression Left;
    //     public readonly Expression Right;

    //     public AdditionExpression(Expression left, Expression right)
    //     {
    //         this.Left = left ?? throw new System.ArgumentNullException(nameof(left));
    //         this.Right = right ?? throw new System.ArgumentNullException(nameof(right));
    //     }
    // }

    // public class ExpressionPrinter
    // {
    //     public void Print(AdditionExpression ae, StringBuilder sb)
    //     {
    //         sb.Append("(");
    //         Print((dynamic)ae.Left, sb);
    //         sb.Append("+");
    //         Print((dynamic)ae.Right, sb);
    //         sb.Append(")");
    //     }

    //     public void Print(DoubleExpression de, StringBuilder sb)
    //     {
    //         sb.Append(de.Value);
    //     }
    // }
}