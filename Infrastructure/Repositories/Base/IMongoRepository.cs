using System.Linq.Expressions;
using Domain.Interfaces.Base;

namespace Infrastructure.Repositories.Base;

/// <summary>
/// Base interface for Mongo Db
/// </summary>
/// <typeparam name="TDocument"></typeparam>
public interface IMongoRepository<TDocument> where TDocument : IDocument
{
    IQueryable<TDocument> AsQueryable();

    IEnumerable<TDocument> FilterBy(
        Expression<Func<TDocument, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectionExpression);

    TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);
    

    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);
    
    IList<TDocument> Find(Expression<Func<TDocument, bool>> filterExpression);
    Task<IList<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filterExpression);

    TDocument FindById(string id);

    Task<TDocument> FindByIdAsync(string id);
    Task<TDocument> FindByShortIdAsync(string id);

    void InsertOne(TDocument document);

    Task InsertOneAsync(TDocument document);

    void InsertMany(ICollection<TDocument> documents);

    Task InsertManyAsync(ICollection<TDocument> documents);

    void ReplaceOne(TDocument document);

    Task ReplaceOneAsync(TDocument document);

    void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    void DeleteById(string id);

    Task DeleteByIdAsync(string id);

    void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
}