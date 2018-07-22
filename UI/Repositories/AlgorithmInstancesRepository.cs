using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;

using Core.Interfaces;
using UI.Classes;
using UI.Exceptions;

namespace UI.Repositories
{
    public class AlgorithmInstancesRepository : IAlgorithmInstancesRepository
    {
        private static Dictionary<Guid, IAlgorithm<object>> _instances = new Dictionary<Guid, IAlgorithm<object>>();
        private IAlgorithmClassesRepository _classesRepository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public (Guid InstanceId, IAlgorithm<object> Instance) Create(Type algorithmType)
        {
            if (!algorithmType.ImplementGenericInterface(typeof(IAlgorithm<>)))
                throw new AlgorithmDoesNotImplementBaseInterfaceException();

            var instanceId = Guid.NewGuid();
            var typeName = algorithmType.AssemblyQualifiedName;

            using (var connection = new DbConnection())
            {
                connection.CreateTableIfNotExists<InstanceRecord>();
                connection.Insert(new InstanceRecord() { InstanceId = instanceId, TypeName = typeName });
            }

            var instance = (IAlgorithm<object>)Activator.CreateInstance(algorithmType);

            _instances.Add(instanceId, instance);

            return (instanceId, instance);
        }

        public Dictionary<Guid, IAlgorithm<object>> All()
        {
            using (var connection = new DbConnection())
            {
                var instancesInDb = connection.GetTableAndCreateIfNotExists<InstanceRecord>();

                var notInstantiated = instancesInDb.Where(x => !_instances.Keys.Contains(x.InstanceId));

                foreach (var i in notInstantiated)
                {
                    Type type = _classesRepository.All().SingleOrDefault(x => x.AssemblyQualifiedName == i.TypeName);

                    if (type == null)
                    {
                        logger.Warn($"There is the instance from the last session that haven't " +
                            $"corresponding class in the current session. ID:{i.InstanceId}");

                        continue;
                    }

                    if (!type.ImplementGenericInterface(typeof(IAlgorithm<>)))
                        throw new AlgorithmDoesNotImplementBaseInterfaceException();
                    
                    _instances.Add(i.InstanceId, (IAlgorithm<object>)Activator.CreateInstance(type));
                }
            }

            return new Dictionary<Guid, IAlgorithm<object>>(_instances);
        }

        private class InstanceRecord
        {
            public Guid InstanceId { get; set; }
            public string TypeName { get; set; }
        }

        public AlgorithmInstancesRepository(IAlgorithmClassesRepository algorithmClassesRepository)
        {
            this._classesRepository = algorithmClassesRepository;
        }
    }
}
