using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Domain.Dtos.CustomerDto
{
    public class GetUpvoteRatingDto
    {
        public decimal Value { get; set; }

    }
}