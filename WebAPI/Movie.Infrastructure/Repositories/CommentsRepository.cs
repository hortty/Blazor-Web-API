using MongoDB.Driver;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Infrastructure.Repositories;

public class CommentsRepository : ICommentsRepository
{
    private readonly IMongoCollection<Comment> _comments;
    public CommentsRepository(IMongoSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _comments = database.GetCollection<Comment>(settings.CommentsCollection);
    }

    public Comment Create(Comment entity)
    {
        _comments.InsertOne(entity);
        return entity;
    }

    public Comment Delete(Comment entity)
    {
        _comments.DeleteOne(comment => comment.Id == entity.Id);
        return entity;
    }

    public List<Comment> ListAll()
    {
        return _comments.Find(comment => true).ToList();
    }

    public Comment ListById(Comment entity)
    {
        return _comments.Find(comment => comment.Id == entity.Id).FirstOrDefault();
    }

    public Comment Update(Comment entity)
    {
        _comments.ReplaceOne(comment => comment.Id == entity.Id, entity);
        return entity;
    }

    public List<Comment> ListByFilmId(Guid filmId)
    {
        return _comments.Find(comment => comment.FilmId == filmId).ToList();
    }
}
