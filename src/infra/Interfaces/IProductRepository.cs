using data.domain.Collections;
using VeggieLink.Infra.domain.Dtos;

namespace VeggieLink.Infra.Interfaces;

public interface IProductRepository
{
    Task Create(ProductCollection collection);
    Task<List<ProductCollection>> GetAllProducts();
    Task<ProductCollection> GetProduct(string id);
    Task UpdateStatus(string id);
    Task UpdateProduct(ProductCollection dto, string id);
    //Task<List<ProductWithCategory>> GetProductsWithCategoriesAsync();
}