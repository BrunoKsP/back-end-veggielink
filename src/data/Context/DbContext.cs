using data.domain.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using VeggieLink.Data.Collections;

namespace data.domain.Context;

public class DbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(IConfiguration config)
    {
        var conn = config["MongoDb:ConnectionString"];
        var database = config["MongoDb:DataBase"];

        var mongoClient = new MongoClient(conn);
        _database = mongoClient.GetDatabase(database);
    }

    public IMongoCollection<ProductCollection> ProductCollection =>
            _database.GetCollection<ProductCollection>("product");
    public IMongoCollection<UserCollection> UserCollection =>
            _database.GetCollection<UserCollection>("user");
    public IMongoCollection<CategoryCollection> CategoryCollection =>
            _database.GetCollection<CategoryCollection>("category");

}