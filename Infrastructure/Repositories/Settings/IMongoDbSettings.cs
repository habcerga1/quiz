namespace Infrastructure.Repositories.Settings;

/// <summary>
/// Mongo db settings interface
/// </summary>
public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}