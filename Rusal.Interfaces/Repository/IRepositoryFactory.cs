﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Repository
{
    public interface IRepositoryFactory
    {
        object CreateInstance(Type type);

        T CreateRepository<T>();
    }
}
