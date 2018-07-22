using System;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.Classes
{
    public abstract class IterativeAlgorithm : Algorithm
    {
        private IIterationsRepository _iterationsRepository;

        protected async override void Computation(Synchronized<bool> isSuspended)
        {
            bool keepIterate = true;

            while (keepIterate)
            {   
                while (isSuspended) await Task.Delay(1000);
                keepIterate = await Iterate(_iterationsRepository, isSuspended);
            }
        }

        protected abstract Task<bool> Iterate(IIterationsRepository iterations, Synchronized<bool> isSuspended);

        public IterativeAlgorithm(IIterationsRepository iterationsRepository, IMathFactory mathFactory)
            : base(mathFactory)
        {
            _iterationsRepository = iterationsRepository;
        }
    }
}
