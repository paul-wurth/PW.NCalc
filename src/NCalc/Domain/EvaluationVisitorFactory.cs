using System.Globalization;

namespace NCalc.Domain
{
    internal class EvaluationVisitorFactory : IEvaluationVisitorFactory
    {
        public IEvaluationVisitor Create(EvaluateOptions options, CultureInfo cultureInfo) => new EvaluationVisitor(options, cultureInfo);
    }
}
