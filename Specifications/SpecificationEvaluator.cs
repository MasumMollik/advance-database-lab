using System.Linq;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class SpecificationEvaluator<TModel> where TModel : BaseModel
    {
        public static IQueryable<TModel> GetQuery(IQueryable<TModel> inputQuery, ISpecification<TModel> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}