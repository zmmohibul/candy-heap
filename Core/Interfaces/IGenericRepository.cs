using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T> specification);
        Task<T> GetEntityWithSpecificationAsync(int id, ISpecification<T> specification);
    }
}