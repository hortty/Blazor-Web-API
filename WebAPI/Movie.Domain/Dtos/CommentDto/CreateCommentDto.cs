using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.CustomerDto
{
    [AutoMap(typeof(Comment), ReverseMap = true)]
    public class CreateCommentDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = String.Empty;

        public string Content { get; set; } = String.Empty;

        public Guid FilmId { get; set; }
    }
}