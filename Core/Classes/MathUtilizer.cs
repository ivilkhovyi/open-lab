using Core.Interfaces;
using System;

namespace Core.Classes
{
    public class MathUtilizer
    {
        private readonly IMathFactory _mathFactory;

        protected IMatrix Matrix(int rows, int cols)
        {
            return _mathFactory.CreateMatrix(rows, cols);
        }

        protected IVector Vector(int len)
        {
            return _mathFactory.CreateVector(len);
        }

        protected IScalarFunction ScalarFunction(string textual)
        {
            return _mathFactory.CreateScalarFunction(textual);
        }

        public MathUtilizer(IMathFactory mathFactory)
        {
            _mathFactory = mathFactory;
        }
    }
}
