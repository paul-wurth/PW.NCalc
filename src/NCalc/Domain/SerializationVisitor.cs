﻿using System;
using System.Globalization;
using System.Text;

namespace NCalc.Domain
{
    public class SerializationVisitor : ILogicalExpressionVisitor
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        public SerializationVisitor()
        {
            Result = new StringBuilder();
            _numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
        }

        public StringBuilder Result { get; protected set; }

        public void Visit(LogicalExpression expression)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Visit(TernaryExpression expression)
        {
            EncapsulateNoValue(expression.LeftExpression);

            Result.Append("? ");

            EncapsulateNoValue(expression.MiddleExpression);

            Result.Append(": ");

            EncapsulateNoValue(expression.RightExpression);
        }

        public void Visit(BinaryExpression expression)
        {
            EncapsulateNoValue(expression.LeftExpression);

            switch (expression.Type)
            {
                case BinaryExpressionType.And:
                    Result.Append("and ");
                    break;

                case BinaryExpressionType.Or:
                    Result.Append("or ");
                    break;

                case BinaryExpressionType.Div:
                    Result.Append("/ ");
                    break;

                case BinaryExpressionType.Equal:
                    Result.Append("= ");
                    break;

                case BinaryExpressionType.Greater:
                    Result.Append("> ");
                    break;

                case BinaryExpressionType.GreaterOrEqual:
                    Result.Append(">= ");
                    break;

                case BinaryExpressionType.Lesser:
                    Result.Append("< ");
                    break;

                case BinaryExpressionType.LesserOrEqual:
                    Result.Append("<= ");
                    break;

                case BinaryExpressionType.Minus:
                    Result.Append("- ");
                    break;

                case BinaryExpressionType.Modulo:
                    Result.Append("% ");
                    break;

                case BinaryExpressionType.NotEqual:
                    Result.Append("!= ");
                    break;

                case BinaryExpressionType.Plus:
                    Result.Append("+ ");
                    break;

                case BinaryExpressionType.Times:
                    Result.Append("* ");
                    break;

                case BinaryExpressionType.BitwiseAnd:
                    Result.Append("& ");
                    break;

                case BinaryExpressionType.BitwiseOr:
                    Result.Append("| ");
                    break;

                case BinaryExpressionType.BitwiseXOr:
                    Result.Append("~ ");
                    break;

                case BinaryExpressionType.LeftShift:
                    Result.Append("<< ");
                    break;

                case BinaryExpressionType.RightShift:
                    Result.Append(">> ");
                    break;
            }

            EncapsulateNoValue(expression.RightExpression);
        }

        public void Visit(UnaryExpression expression)
        {
            switch (expression.Type)
            {
                case UnaryExpressionType.Not:
                    Result.Append("!");
                    break;

                case UnaryExpressionType.Negate:
                    Result.Append("-");
                    break;

                case UnaryExpressionType.BitwiseNot:
                    Result.Append("~");
                    break;
            }

            EncapsulateNoValue(expression.Expression);
        }

        public void Visit(ValueExpression expression)
        {
            switch (expression.Type)
            {
                case ValueType.Boolean:
                    Result.Append(expression.Value.ToString()).Append(" ");
                    break;

                case ValueType.DateTime:
                    Result.Append("#").Append(expression.Value.ToString()).Append("#").Append(" ");
                    break;

                case ValueType.Float:
                    Result.Append(decimal.Parse(expression.Value.ToString()).ToString(_numberFormatInfo)).Append(" ");
                    break;

                case ValueType.Integer:
                    Result.Append(expression.Value.ToString()).Append(" ");
                    break;

                case ValueType.String:
                    Result.Append("'").Append(expression.Value.ToString()).Append("'").Append(" ");
                    break;
            }
        }

        public void Visit(Function function)
        {
            Result.Append(function.Identifier.Name);

            Result.Append("(");

            for (int i = 0; i < function.Expressions.Length; i++)
            {
                function.Expressions[i].Accept(this);
                if (i < function.Expressions.Length - 1)
                {
                    Result.Remove(Result.Length - 1, 1);
                    Result.Append(", ");
                }
            }

            // trim spaces before adding a closing paren
            while (Result[Result.Length - 1] == ' ')
                Result.Remove(Result.Length - 1, 1);

            Result.Append(") ");
        }

        public void Visit(Identifier parameter)
        {
            Result.Append("[").Append(parameter.Name).Append("] ");
        }

        protected void EncapsulateNoValue(LogicalExpression expression)
        {
            if (expression is ValueExpression)
            {
                expression.Accept(this);
            }
            else
            {
                Result.Append("(");
                expression.Accept(this);

                // trim spaces before adding a closing paren
                while (Result[Result.Length - 1] == ' ')
                    Result.Remove(Result.Length - 1, 1);

                Result.Append(") ");
            }
        }
    }
}
