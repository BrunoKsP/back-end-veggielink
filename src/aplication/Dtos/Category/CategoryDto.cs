using VeggieLink.Aplication.Dtos.Products;

namespace VeggieLink.Aplication.Dtos.Category;

public class CategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}