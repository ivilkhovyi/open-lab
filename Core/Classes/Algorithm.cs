using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Classes
{
    public abstract class Algorithm : MathUtilizer, IAlgorithm
    {
        private Task _task;
        private Synchronized<bool> _isSuspended;

        protected abstract void Computation(Synchronized<bool> isSuspended);

        public virtual async void Resume()
        {
            _isSuspended.Value = false;

            if (_task == null)
            {
                _task = new Task(() => Computation(_isSuspended));
                await _task;
            }
        }

        public virtual void Suspend()
        {
            _isSuspended.Value = true;
        }

        public Algorithm(IMathFactory mathFactory)
            : base(mathFactory)
        {
            _isSuspended = new Synchronized<bool>(value: true);
        }
    }
}
