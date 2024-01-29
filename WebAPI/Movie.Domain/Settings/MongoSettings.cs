using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string CommentsCollection { get; set; } = String.Empty;
        public string UpvoteCollection { get; set; } = String.Empty;
    }
}
