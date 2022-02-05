using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T> specification)
        {
            var queryable = _context.Set<T>().AsQueryable().AsNoTracking();
            queryable = SpecificationEvaluator<T>.GetQueryable(queryable, specification);
            return await queryable.ToListAsync();
        }

        public async Task<T> GetEntityWithSpecificationAsync(int id, ISpecification<T> specification)
        {
            var queryable = _context.Set<T>().AsQueryable().AsNoTracking();
            queryable = SpecificationEvaluator<T>.GetQueryable(queryable, specification);
            return await queryable.FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}