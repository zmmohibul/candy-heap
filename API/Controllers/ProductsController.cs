using System;
using System.Threading.Tasks;
using Core.Domain;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _genericProductRepository;

        public ProductsController(IProductRepository productRepository, IGenericRepository<Product> genericProductRepository)
        {
            _productRepository = productRepository;
            _genericProductRepository = genericProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int typeId, [FromQuery] int brandId)
        {
            Console.WriteLine(typeId);
            Console.WriteLine(brandId);
            var specification = new BaseSpecification<Product>();
            if (typeId > 0)
            {
                specification.AddWhereExpression(p => p.ProductTypeId == typeId);
            }
            
            if (brandId > 0)
            {
                specification.AddWhereExpression(p => p.ProductBrandId == brandId);
            }
            
            specification.AddIncludeExpression(p => p.ProductBrand);
            specification.AddIncludeExpression(p => p.ProductType);

            // var products = await _genericProductRepository.GetAllAsync();
            var products = await _genericProductRepository.GetAllWithSpecificationAsync(specification);
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var specification = new BaseSpecification<Product>();
            specification.AddIncludeExpression(p => p.ProductBrand);
            specification.AddIncludeExpression(p => p.ProductType);

            var product = await _genericProductRepository.GetEntityWithSpecificationAsync(id, specification);
            return Ok(product);
        }
    }
}