using System;

namespace Vistor.Coding.Exercise
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value value);
        public abstract void Visit(AdditionExpression ae);
        public abstract void Visit(MultiplicationExpression me);
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            throw new NotImplementedException();
        }

        // todo
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            throw new NotImplementedException();
        }

        // todo
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            throw new NotImplementedException();
        }

        // todo
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        public override void Visit(Value value)
        {
            // todo
        }

        public override void Visit(AdditionExpression ae)
        {
            // todo
        }

        public override void Visit(MultiplicationExpression me)
        {
            // todo
        }

        public override string ToString()
        {
            // todo
            return "";
        }
    }
}