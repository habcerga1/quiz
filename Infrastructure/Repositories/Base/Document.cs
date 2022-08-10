using MongoDB.Bson;

namespace Infrastructure.Repositories.Base;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public  string ShortId { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}