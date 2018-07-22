﻿using Core.Classes;
using Core.Interfaces;

namespace OptimizationMethods
{
    public class CoordinateDescentMethod : IterativeAlgorithm<CoordinateDescentMethod.Result>
    {
        private readonly IVector x_0;
        private readonly IVector[] directions;
        private readonly double e;
        private readonly int n;

        protected override bool Iterate(IIterationsRepository iterations)
        {
            return true;
        }

        protected override Result GetResult(IIterationsRepository iterations)
        {
            var finalIteration = iterations.Last<Iteration>();
            return new Result() { x_final = finalIteration.x_i, f_x_final = finalIteration.f_x_i };
        }

        public class InitialParams
        {
            public IVector x_0;
            public double e;
        }

        public class Iteration
        {
            public double i;
            public IVector x_i;
            public IVector f_x_i;
        }

        public class Result
        {
            public IVector x_final;
            public IVector f_x_final;
        }

        public CoordinateDescentMethod(IIterationsRepository iterationsRepository, IInitialParamsRepository initialParamsRepository, IMathFactory mathFactory)
            : base(iterationsRepository, mathFactory)
        {
            InitialParams initialParams = initialParamsRepository.Get<InitialParams>();
            this.x_0 = initialParams.x_0;
            this.e = initialParams.e;
            this.n = x_0.firstDimension;
            this.directions = new IVector[n];
            for (int i = 0; i < n; i++)
            {
                directions[i] = NewVector(n);
                directions[i][i] = NewScalar(1);
            }
        }
    }
}
