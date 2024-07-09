using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IUpvoteRepository
    {
        public Upvote Create(Upvote entity);

        public Upvote Update(Upvote entity);

        public Upvote Delete(Upvote entity);

        public List<Upvote> ListAll();

        public Upvote ListById(Upvote entity);

        public List<Upvote> ListByFilmId(Guid filmId);
    }
}
