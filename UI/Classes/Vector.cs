using Core.Interfaces;
using System;

namespace UI.Classes
{
    public class Vector : Matrix, IVector
    {
        public Vector(long len, IMathFactory mathFactory)
            : base(len, 1, mathFactory)
        {
        }

        public IScalar this[int i] { get => this[i, 1]; set => this[i, 1] = value; }
    }
}
