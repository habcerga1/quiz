using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Interfaces.Base;

/// <summary>
/// Base Mongo entity interface
/// </summary>
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