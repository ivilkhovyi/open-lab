using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace UI.Repositories
{
    interface IAlgorithmInstancesRepository
    {
        (Guid InstanceId, IAlgorithm<object> Instance) Create(Type type);
        Dictionary<Guid, IAlgorithm<object>> All();
    }
}
