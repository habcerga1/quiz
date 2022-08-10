using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Repositories.Base;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }
    
    string ShortId
    {
        get => Id.ToString();
    }

    DateTime CreatedAt { get; }
}