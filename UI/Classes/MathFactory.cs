using Core.Classes;
using Core.Interfaces;
using System;

namespace UI.Classes
{
    public class MathFactory : IMathFactory
    {
        public IMatrix Matrix(int rows, int cols, IMathFactory mathFactory)
        {
            return new Matrix(rows, cols, mathFactory);
        }

        public double CreateScalar(double value, IMathFactory mathFactory)
        {
            return new Scalar(value, mathFactory);
        }

        public IScalarFunction CreateScalarFunction(string textualForm, IMathFactory mathFactory)
        {
            return new ScalarFunction(textualForm, mathFactory);
        }

        public IVector CreateVector(long len, IMathFactory mathFactory)
        {
            return new Vector(len, mathFactory);
        }
    }
}
