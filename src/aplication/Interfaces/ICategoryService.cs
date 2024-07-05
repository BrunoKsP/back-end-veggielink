using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Data.Collections;

namespace VeggieLink.Aplication.Interfaces;

public interface ICategoryService
{
    Task Create(CreateCategoryDto dto);
    Task<IList<CategoryCollection>> GetAllCategorys();
    Task<CategoryDto> GetCategory(string id);
}