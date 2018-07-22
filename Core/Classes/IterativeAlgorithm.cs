using System;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.Classes
{
    public abstract class IterativeAlgorithm<TInitialParams, TIteration, TResult> 
        : Algorithm<TInitialParams, TResult>
        where TInitialParams : class
        where TIteration : class
        where TResult : class
    {
        private IIterationsRepository _iterationsRepository;

        protected async override Task<TResult> Computation(Synchronized<bool> isPaused, Synchronized<bool> _isCancelled)
        {
            while (!_isCancelled)
            {   
                while (isPaused) await Task.Delay(1000);
                bool keepIterate = Iterate(_iterationsRepository);
                if (!keepIterate) break;
            }

            return GetResult(_iterationsRepository);
        }

        protected abstract bool Iterate(IIterationsRepository iterations);

        protected abstract TResult GetResult(IIterationsRepository iterations);

        public Type GetIterationClassType => typeof(TIteration);

        public IterativeAlgorithm(IIterationsRepository iterationsRepository, IMathFactory mathFactory)
            : base(mathFactory)
        {
            _iterationsRepository = iterationsRepository;
        }
    }
}
