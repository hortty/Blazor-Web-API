using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface ICommentsService
    {
        public Task<CreatedCommentDto> Create(CreateCommentDto createCommentDto);

        public List<FoundCommentDto> ListAll();

        public List<FoundCommentDto> ListByFilmId(Guid filmId);
    }
}
