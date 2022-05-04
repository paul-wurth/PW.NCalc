namespace NCalc.Domain
{
    public class Identifier : LogicalExpression
    {
        public Identifier(string name)
        {
            Name = name;
        }

        public string Name { get; set; }


        public override void Accept(ILogicalExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
