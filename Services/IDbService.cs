using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceCalculator.Services
{
    public interface IDbService<T>
    {
        Task<List<T>> GetAsync();

        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(T model);

        Task<bool> IsExists(Guid id);
    }
}
