using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace UI.Classes
{
    public class InMemoryInitialParamsRepository : IInitialParamsRepositoryWithWriteAccess
    {
        private static Dictionary<Guid, object> _data = new Dictionary<Guid, object>();

        private Guid _algorithmId;

        public T Get<T>()
        {
            if (!_data.ContainsKey(_algorithmId))
            {
                return default;
            }

            return (T)_data[_algorithmId];
        }

        public void Set<T>(T parameters)
        {
            _data.Add(_algorithmId, (object)parameters);
        }

        public InMemoryInitialParamsRepository(Guid algorithmId)
        {
            _algorithmId = algorithmId;
        }
    }
}
