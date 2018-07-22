using Core.Classes;
using Core.Interfaces;
using System.Threading.Tasks;

namespace OptimizationMethods
{
    public class CoordinateDescentMethod : IterativeAlgorithm
    {
        private readonly IVector x_0;
        private readonly IVector[] directions;
        private readonly double e;
        private readonly int n;

        protected override async Task<bool> Iterate(IIterationsRepository iterations, Synchronized<bool> isSuspended)
        {
            while (isSuspended) await Task.Delay(1000);
            return true;
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
                directions[i] = Vector(n);
                directions[i][i] = 1.0;
            }
        }
    }
}
