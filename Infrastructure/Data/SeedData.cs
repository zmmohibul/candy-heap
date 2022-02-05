using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/type-data.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    
                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }
                
                if (!context.ProductBrands.Any())
                {
                    var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brand-data.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    
                    context.ProductBrands.AddRange(brands);
                    await context.SaveChangesAsync();
                }
                
                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/data.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<SeedData>();
                logger.LogError(exception.Message);
            }
        }
    }
}