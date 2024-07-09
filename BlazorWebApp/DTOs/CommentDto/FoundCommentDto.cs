using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWebApp.DTOs.CommentDto
{
    public class FoundCommentDto
    {

        public string Id { get; set; } = String.Empty;


        public Guid UserId { get; set; }


        public string UserName { get; set; } = String.Empty;


        public string Content { get; set; } = String.Empty;


        public Guid FilmId { get; set; }
    }
}