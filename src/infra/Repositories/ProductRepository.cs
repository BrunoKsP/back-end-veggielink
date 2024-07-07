using data.domain.Collections;
using data.domain.Context;
using MongoDB.Driver;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    protected IMongoCollection<ProductCollection> _dataBase;
    protected IMongoCollection<CategoryCollection> _category;

    public ProductRepository(DbContext context, IMongoCollection<CategoryCollection> category)
    {
        _dataBase = context.ProductCollection;
        _category = category;
    }

    public async Task Create(ProductCollection collection)
    {
        await _dataBase.InsertOneAsync(collection);
    }
    public async Task<List<ProductCollection>> GetAllProducts()
    {
        return await _dataBase.Find(_ => true).ToListAsync();
    }
    public async Task<ProductCollection> GetProduct(string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);
        return await _dataBase.Find(filter).FirstOrDefaultAsync();
    }
    public async Task UpdateStatus(string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);
        var update = Builders<ProductCollection>.Update.Set(p => p.Status, 0);

        await _dataBase.UpdateOneAsync(filter, update);
    }
    public async Task UpdateProduct(ProductCollection dto, string id)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.Id, id);

        var update = Builders<ProductCollection>.Update
            .Set(p => p.Name, dto.Name)
            .Set(p => p.Description, dto.Description)
            .Set(p => p.PlantingDate, dto.PlantingDate)
            .Set(p => p.HarverstDate, dto.HarverstDate)
            .Set(p => p.PreparingDate, dto.PreparingDate)
            .Set(p => p.CategoryId, dto.CategoryId)
            .Set(p => p.Fertilizer, dto.Fertilizer)
            .Set(p => p.Observation, dto.Observation)
            .Set(p => p.Thumb, dto.Thumb)
            .Set(p => p.Status, dto.Status);

        await _dataBase.UpdateOneAsync(filter, update);
    }
    public async Task<IList<ProductCollection>> GetProductCategory(string categoryId)
    {
        var filter = Builders<ProductCollection>.Filter.Eq(p => p.CategoryId, categoryId);
        return await _dataBase.Find(filter).ToListAsync();
    }
}
