using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PerformanceCalculator.Models;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Services
{
    public interface IDbService<T> where T: BaseModel
    {
        Task<IReadOnlyList<T>> GetAsync();

        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(T model);

        Task<bool> IsExists(Guid id);

        Task<T> GetModelWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
