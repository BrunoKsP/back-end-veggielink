using data.domain.Mappings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using VeggieLink.Data.Collections;

namespace VeggieLink.Data.Mappings;

public class CategoryMapping : DocumentMapping<CategoryCollection>
{
    public override void Map(BsonClassMap<CategoryCollection> cm)
    {
        cm.MapIdField(p => p.Id)
      .SetIdGenerator(StringObjectIdGenerator.Instance);

        cm.MapField(p => p.Name)
          .SetElementName("name");
    }
}