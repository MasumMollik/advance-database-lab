using System;
using System.Collections.Generic;

namespace PerformanceCalculator.Services
{
    public interface IDbService<T>
    {
        List<T> Get();
        T GetById(Guid id);
        void Create(T model);
    }
}