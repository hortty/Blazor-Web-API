using MongoDB.Driver;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Movie.Infrastructure.Repositories;

public class UpvoteRepository : IUpvoteRepository
{
    private readonly IMongoCollection<Upvote> _upvotes;
    public UpvoteRepository(IMongoSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _upvotes = database.GetCollection<Upvote>(settings.UpvoteCollection);
    }

    public Upvote Create(Upvote entity)
    {
        _upvotes.InsertOne(entity);
        return entity;
    }

    public Upvote Delete(Upvote entity)
    {
        _upvotes.DeleteOne(upvote => upvote.Id == entity.Id);
        return entity;
    }

    public Upvote ListById(Upvote entity)
    {
        return _upvotes.Find(upvote => upvote.Id == entity.Id).FirstOrDefault();
    }

    public Upvote Update(Upvote entity)
    {
        _upvotes.ReplaceOne(upvote => upvote.Id == entity.Id, entity);
        return entity;
    }

    public List<Upvote> ListAll()
    {
        return _upvotes.Find(upvote => true).ToList();
    }

    public List<Upvote> ListByFilmId(Guid filmId)
    {
        return _upvotes.Find(upvote => upvote.FilmId == filmId).ToList();
    }
}
