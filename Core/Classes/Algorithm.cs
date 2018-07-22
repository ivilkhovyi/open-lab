using System;
using System.Threading.Tasks;
using Core.Interfaces;
using MorseCode.ITask;

namespace Core.Classes
{
    public abstract class Algorithm<TInitialParams, TResult> : MathUtilizer, IAlgorithm<TInitialParams, TResult> 
        where TInitialParams : class
        where TResult : class
    {
        private Task<TResult> _task;
        private Synchronized<bool> _isPaused;
        private Synchronized<bool> _isCancelled;

        protected abstract Task<TResult> Computation(Synchronized<bool> isPaused, Synchronized<bool> _isCancelled);

        public virtual ITask<TResult> GetTask()
        {
            if (_task == null)
            {
                _task = Computation(_isPaused, _isCancelled);
            }

            return _task.AsITask<TResult>();
        }

        public virtual void Pause()
        {
            _isPaused.Value = true;
        }

        public virtual async void Resume()
        {
            if (_isCancelled) return;

            _isPaused.Value = false;

            if (_task.Status != TaskStatus.Running)
                await GetTask();
        }

        public virtual void Cancell()
        {
            _isCancelled.Value = true;
        }

        public virtual bool IsRunning =>
            _isPaused == false &&
            _isCancelled == false &&
            _task.Status == TaskStatus.Running;

        public Type GetInitialParamsClassType => typeof(TInitialParams);
        public Type GetResultClassType => typeof(TResult);

        public Algorithm(IMathFactory mathFactory)
            : base(mathFactory)
        {
            _isPaused = new Synchronized<bool>(false);
            _isCancelled = new Synchronized<bool>(false);
        }
    }
}
