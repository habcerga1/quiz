using Domain.Interfaces.Base;
using MongoDB.Bson;

namespace Domain.Models.Base;

/// <summary>
/// Base Mongo entity
/// </summary>
public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public  string ShortId { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}