using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.ShoppingCartMovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface IShoppingCartMovieService
    {
        Task<ResultDTO<CreatedShoppingCartMovieDto>> CreateAsync(CreateShoppingCartMovieDto dto);
        Task<ResultDTO<DeletedShoppingCartMovieDTO>> DeleteAsync(DeleteShoppingCartMovieDTO dto);
        Task<ResultDTO<List<FoundShoppingCartMovieDto>>> GetAsync();
    }
}
