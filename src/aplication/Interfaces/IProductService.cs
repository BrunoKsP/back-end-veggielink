using aplication.Dtos.Products;
using VeggieLink.Aplication.Dtos.Products;

namespace aplication.Services;

public interface IProductService
{
    Task Create(CreateProductDto dto);
    Task<Dictionary<string, List<ProductDto>>> GetAllProducts();
    Task<ListProductDto> GetProduct(string id);
    Task ChangeProduct(ChangeProductDto dto, string id);
}