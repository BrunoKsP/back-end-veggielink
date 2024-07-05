using data.domain.Mappings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using VeggieLink.Data.Collections;

namespace VeggieLink.Data.Mappings;

public class UserMapping : DocumentMapping<UserCollection>
{
  public override void Map(BsonClassMap<UserCollection> cm)
  {
    cm.MapIdField(u => u.Id)
    .SetIdGenerator(StringObjectIdGenerator.Instance);

    cm.MapField(u => u.Status)
      .SetElementName("status")
      .SetDefaultValue(1);

    cm.MapField(u => u.Name)
      .SetElementName("name");

    cm.MapField(u => u.Email)
      .SetElementName("email");

    cm.MapField(u => u.Password)
      .SetElementName("password");

    cm.MapField(u => u.Photo)
      .SetElementName("photo");

    cm.MapField(u => u.Description)
      .SetElementName("description");

    cm.MapProperty(u => u.Segment)
        .SetElementName("segment");

    cm.MapField(u => u.CreateDate)
      .SetElementName("create_date");
  }
}