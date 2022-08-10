using MongoDB.Driver;

namespace Infrastructure.Repositories.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public MongoCredential Credential = MongoCredential.CreateCredential("Quiz", "habcerga1", "zAvPIsgp9m5ji0ar");
}