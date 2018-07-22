using Core.Interfaces;
using System;

namespace UI.Classes
{
    public class Matrix : IMatrix
    {
        private IMathFactory _mathFactory;

        protected double[,] _content;

        public Matrix(int rows, int cols, IMathFactory mathFactory)
        {
            _mathFactory = mathFactory;
            _content = new double[rows, cols];
        }

        public int firstDimension => _content.GetLength(0);

        public int secondDimension => _content.GetLength(1);

        public IScalar this[long row, long col]
        {
            get => _mathFactory.CreateScalar(_content[row, col], _mathFactory);
            set => _content[row, col] = value.GetSystemDouble;
        }
    }
}
