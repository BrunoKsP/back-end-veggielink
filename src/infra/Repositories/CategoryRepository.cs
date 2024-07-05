using data.domain.Context;
using MongoDB.Driver;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    protected IMongoCollection<CategoryCollection> _dataBase;

    public CategoryRepository(DbContext context)
    {
        _dataBase = context.CategoryCollection;
    }
    public async Task Create(CategoryCollection collection)
    {
        await _dataBase.InsertOneAsync(collection);
    }
    public async Task<List<CategoryCollection>> GetAllCategorys()
    {
        return await _dataBase.Find(_ => true).ToListAsync();
    }
    public async Task<CategoryCollection> GetCategory(string id)
    {
        var filter = Builders<CategoryCollection>.Filter.Eq(p => p.Id, id);
        return await _dataBase.Find(filter).FirstOrDefaultAsync();
    }
   public async Task<List<CategoryCollection>> GetCategoriesById(List<string> ids)
{
    var filter = Builders<CategoryCollection>.Filter.In(p => p.Id, ids);
    return await _dataBase.Find(filter).ToListAsync();
}
}