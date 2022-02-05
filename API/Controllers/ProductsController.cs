using System;
using System.Threading.Tasks;
using Core.Interfaces;
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

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int typeId, [FromQuery] int brandId)
        {
            Console.WriteLine(typeId);
            Console.WriteLine(brandId);

            if (typeId > 0 && brandId == 0)
            {
                return Ok(await _productRepository.GetProductByTypeId(typeId));
            }
            
            if (typeId == 0 && brandId > 0)
            {
                return Ok(await _productRepository.GetProductByBrandId(brandId));
            }
            
            if (typeId > 0 && brandId > 0)
            {
                return Ok(await _productRepository.GetProductByTypeAndBrandId(typeId, brandId));
            }
            
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return Ok(product);
        }
    }
}