using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Dtos.UserDto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class GetUserPaginatedDTO
    {
        public int page { get; set; }
    }
}
