using System.Linq;
using Core.Domain;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQueryable(IQueryable<T> inputQueryable, ISpecification<T> specification)
        {
            foreach (var expression in specification.WhereExpressions)
            {
                inputQueryable = inputQueryable.Where(expression);
            }

            foreach (var expression in specification.IncludeExpressions)
            {
                inputQueryable = inputQueryable.Include(expression);
            }

            return inputQueryable;
        }
    }
}