using System.Text;

namespace Vistor
{
    public abstract class Expression
    {
        
    }

    public static class ExpressionPrinter
    {
        public static void Print(Expression e, StringBuilder sb)
        {
            if (e is DoubleExpression de)
            {
                sb.Append(de.Value);
            }
            else if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.Left, sb);
                sb.Append("+");
                Print(ae.Right, sb);
                sb.Append(")");
            }
        }
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