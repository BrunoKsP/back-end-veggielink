using VeggieLink.Data.Collections;

namespace VeggieLink.Infra.Interfaces;

public interface ICategoryRepository
{
    Task Create(CategoryCollection collection);
    Task<List<CategoryCollection>> GetAllCategorys();
    Task<CategoryCollection> GetCategory(string id);
    Task<List<CategoryCollection>> GetCategoriesById(List<string> id);
    
}