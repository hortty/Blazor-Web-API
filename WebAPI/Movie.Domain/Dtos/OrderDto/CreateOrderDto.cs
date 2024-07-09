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
    [AutoMap(typeof(Order), ReverseMap = true)]
    public class CreateOrderDto
    {
        public string ContentBody { get; set; } = String.Empty;

        public string Title { get; set; } = String.Empty;

        public int? OrderNumber { get; set; }

        public List<string>? Emails { get; set; }
    }
}