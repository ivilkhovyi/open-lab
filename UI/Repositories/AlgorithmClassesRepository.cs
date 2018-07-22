using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Core.Interfaces;
using UI.Classes;

namespace UI.Repositories
{
    public class AlgorithmClassesRepository : IAlgorithmClassesRepository
    {
        private static List<Type> _classes;

        public IEnumerable<Type> All()
        {
            if (_classes == null)
            {
                _classes = new List<Type>();

                var path = Path.GetDirectoryName(Application.ExecutablePath);

                foreach (string dll in Directory.GetFiles(path, "*.dll"))
                {
                    _classes.AddRange(
                        Assembly.LoadFrom(dll).GetTypes()
                        .Where(m => m.ImplementGenericInterface(typeof(IAlgorithm<>)) && !m.IsAbstract));
                } 
            }

            return _classes.AsQueryable();
        }
    }
}
