using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductByBrandId(int brandId);
        Task<List<Product>> GetProductByTypeId(int typeId);
        Task<List<Product>> GetProductByTypeAndBrandId(int typeId, int brandId);
    }
}