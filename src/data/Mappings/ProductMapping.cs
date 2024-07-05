using data.domain.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace data.domain.Mappings;

public class ProductMapping : DocumentMapping<ProductCollection>
{
  public override void Map(BsonClassMap<ProductCollection> cm)
  {
    cm.MapIdField(p => p.Id)
          .SetIdGenerator(StringObjectIdGenerator.Instance);

    cm.MapField(p => p.Status)
      .SetElementName("status")
      .SetDefaultValue(1);

    cm.MapField(p => p.Name)
      .SetElementName("name");

    cm.MapField(p => p.Description)
      .SetElementName("description");

    cm.MapProperty(p => p.PlantingDate)
        .SetElementName("planting_date");

    cm.MapField(p => p.HarverstDate)
      .SetElementName("harvest_date");

    cm.MapProperty(p => p.PreparingDate)
      .SetElementName("preparing_date");

    cm.MapField(p => p.Observation)
      .SetElementName("observation");

    cm.MapField(p => p.Fertilizer)
     .SetElementName("fertilizer");

    cm.MapProperty(p => p.Thumb)
        .SetElementName("thumb");

    cm.MapField(p => p.CategoryId)
            .SetElementName("category_id");
  }
}