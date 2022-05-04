using NCalc.Domain;

namespace NCalc
{
    public static class NCalcSettings
    {
        private readonly static object __lockObj = new object();

        private static IEvaluationVisitorFactory evaluationVisitorFactory = new EvaluationVisitorFactory();

        public static IEvaluationVisitorFactory EvaluationVisitorFactory
        {
            get
            {
                lock (__lockObj)
                {
                    return evaluationVisitorFactory;
                }
            }
            set
            {
                lock (__lockObj)
                {
                    evaluationVisitorFactory = value;
                }
            }
        }
    }
}
