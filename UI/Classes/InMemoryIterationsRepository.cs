using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace UI.Classes
{
    public class InMemoryIterationsRepository : IIterationsRepository
    {
        private static Dictionary<(Guid AlgorithmId, Type tableType), List<object>> _data
            = new Dictionary<(Guid AlgorithmId, Type tableType), List<object>>();

        private Guid _algorithmId;

        private List<object> GetTable(Type tableType)
        {
            if (!_data.ContainsKey((_algorithmId, tableType)))
            {
                _data.Add((_algorithmId, tableType), new List<object>());
            }

            return _data[(_algorithmId, tableType)];
        }

        public void Add<T>(T iteration)
        {
            GetTable(tableType: typeof(T)).Add((object)iteration);
        }

        public IEnumerable<T> All<T>()
        {
            return GetTable(tableType: typeof(T)).Cast<T>();
        }

        public T Last<T>()
        {
            return All<T>().Last();
        }

        public T BeforeLast<T>(int n)
        {
            throw new System.NotImplementedException();
        }

        public InMemoryIterationsRepository(Guid algorithmId)
        {
            _algorithmId = algorithmId;
        }
    }
}
