using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWebApp.DTOs.UpvoteDto
{

    public class CreateUpvoteDto
    {

        public string Id { get; set; } = String.Empty;


        public Guid UserId { get; set; }


        public int Value { get; set; }

 
        public Guid FilmId { get; set; }
    }
}