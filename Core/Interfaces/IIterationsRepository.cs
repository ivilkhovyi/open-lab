using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IIterationsRepository
    {
        T Last<T>();
        T BeforeLast<T>(int nTimesBeforeLast);
        IEnumerable<T> All<T>();
        void Add<T>(T iteration);
    }
}
