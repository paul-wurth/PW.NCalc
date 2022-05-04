namespace NCalc.Domain
{
    public interface ILogicalExpressionVisitor
    {
        void Visit(LogicalExpression expression);
        void Visit(TernaryExpression expression);
        void Visit(BinaryExpression expression);
        void Visit(UnaryExpression expression);
        void Visit(ValueExpression expression);
        void Visit(Function function);
        void Visit(Identifier function);
    }
}
