using System.Globalization;

namespace NCalc.Domain
{
    public interface IEvaluationVisitorFactory
    {
        IEvaluationVisitor Create(EvaluateOptions options, CultureInfo cultureInfo);
    }
}
