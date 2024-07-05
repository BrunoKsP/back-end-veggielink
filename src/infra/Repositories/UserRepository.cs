using data.domain.Context;
using MongoDB.Driver;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Infra.Repositories;

public class UserRepository : IUserRepository
{
    protected IMongoCollection<UserCollection> _dataBase;

    public UserRepository(DbContext context)
    {
        _dataBase = context.UserCollection;
    }

    public async Task Create(UserCollection collection)
    {
        await _dataBase.InsertOneAsync(collection);
    }
    public async Task UpdateUser(UserCollection dto, string id)
    {
        var filter = Builders<UserCollection>.Filter.Eq(p => p.Id, id);

        var update = Builders<UserCollection>.Update
            .Set(p => p.Name, dto.Name)
            .Set(p => p.Description, dto.Description)
            .Set(p => p.Segment, dto.Segment)
            .Set(p => p.Email, dto.Email)
            .Set(p => p.Photo, dto.Photo)
            .Set(p => p.Status, dto.Status);

        await _dataBase.UpdateOneAsync(filter, update);
    }
    public async Task<UserCollection> FindByEmail(string email)
    {
        var filter = Builders<UserCollection>.Filter.Eq(p => p.Email, email);
        return await _dataBase.Find(filter).FirstOrDefaultAsync();
    }
}