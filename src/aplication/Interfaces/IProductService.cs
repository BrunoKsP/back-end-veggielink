using aplication.Dtos.Products;
using data.domain.Collections;
using VeggieLink.Aplication.Dtos.Products;

namespace VeggieLink.Aplication.Interfaces;

public interface IProductService
{
    Task Create(CreateProductDto dto);
    Task<Dictionary<string, List<ProductDto>>> GetAllProducts();
    Task<ProductCollection> GetProduct(string id);
    Task ChangeProduct(ChangeProductDto dto, string id);
}