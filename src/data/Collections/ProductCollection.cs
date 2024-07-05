using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VeggieLink.Data.Collections;

namespace data.domain.Collections;

public class ProductCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Thumb { get; set; }
    public string Fertilizer { get; set; }
    public string Observation { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarverstDate { get; set; }
    public DateTime PreparingDate { get; set; }
    public string CategoryId { get; set; }
}