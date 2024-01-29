using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface ICommentsRepository
    {
        public Comment Create(Comment entity);

        public Comment Update(Comment entity);

        public Comment Delete(Comment entity);

        public List<Comment> ListAll();

        public Comment ListById(Comment entity);

        public List<Comment> ListByFilmId(Guid filmId);
    }
}
