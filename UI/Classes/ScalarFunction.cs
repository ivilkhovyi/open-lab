using Core.Interfaces;
using org.mariuszgromada.math.mxparser;

namespace UI.Classes
{
    public class ScalarFunction : IScalarFunction
    {
        private string _textualForm;
        private IMathFactory _mathFactory;

        public IScalar Compute(IVector x)
        {
            Argument[] arguments = new Argument[x.firstDimension];
            for (int i = 0; i < x.firstDimension; i++)
            {
                arguments[i] = new Argument("x" + (i + 1), x[i].GetSystemDouble);
            }
            var expr = new Expression(_textualForm, arguments);
            return  _mathFactory.CreateScalar(expr.calculate(), _mathFactory);
        }

        public ScalarFunction(string textualForm, IMathFactory mathFactory)
        {
            _mathFactory = mathFactory;
            _textualForm = textualForm;
        }
    }
}
