using System.Collections.Generic;

namespace NCalc.Domain
{
    public interface IEvaluationVisitor : ILogicalExpressionVisitor
    {
        Dictionary<string, object> Parameters { get; set; }
        object Result { get; }

        event EvaluateFunctionHandler EvaluateFunction;
        event EvaluateParameterHandler EvaluateParameter;

        int CompareUsingMostPreciseType(object a, object b);
    }
}