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
    public class FoundUpvoteDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        public Guid UserId { get; set; }

        [BsonElement("value")]
        public string Value { get; set; } = String.Empty;

        [BsonElement("filmId")]
        public Guid FilmId { get; set; }
    }
}