using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace Movie.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("userId")]
        public Guid UserId { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; } = String.Empty;

        [BsonElement("content")]
        public string Content { get; set; } = String.Empty;

        [BsonElement("filmId")]
        public Guid FilmId { get; set; }

    }
}
