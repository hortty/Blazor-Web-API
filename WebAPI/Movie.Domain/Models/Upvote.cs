using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace Movie.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Upvote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        public Guid UserId { get; set; }

        [BsonElement("value")]
        public int Value { get; set; }

        [BsonElement("filmId")]
        public Guid FilmId { get; set; }

    }
}
