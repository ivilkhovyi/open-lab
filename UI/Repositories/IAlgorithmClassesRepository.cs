using System;
using System.Collections.Generic;

namespace UI.Repositories
{
    public interface IAlgorithmClassesRepository
    {
        IEnumerable<Type> All();
    }
}
