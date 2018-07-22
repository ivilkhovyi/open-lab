using MorseCode.ITask;
using System;

namespace Core.Interfaces
{
    public interface IAlgorithm<out TInitialParams, out TResult> 
        where TInitialParams : class
        where TResult : class
    {
        Type GetInitialParamsClassType { get; }
        Type GetResultClassType { get; }
        ITask<TResult> GetTask();
        void Resume();
        void Pause();
        void Cancell();
        bool IsRunning { get; }
    }
}
