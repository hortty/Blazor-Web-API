using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IUpvoteService
    {
        public CreatedUpvoteDto Create(CreateUpvoteDto createUpvoteDto);

        public List<FoundUpvoteDto> ListAll();

        public List<FoundUpvoteDto> ListByFilmId(Guid filmId);

        public GetUpvoteRatingDto UpvoteRatingDtoByFilmId(Guid filmId);
    }
}
