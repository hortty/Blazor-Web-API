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
    [AutoMap(typeof(Upvote), ReverseMap = true)]
    public class CreateUpvoteDto
    {

        public Guid UserId { get; set; }

        public int Value { get; set; }

        public Guid FilmId { get; set; }
    }
}