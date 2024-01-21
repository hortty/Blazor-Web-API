using Microsoft.EntityFrameworkCore;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        DbSet<Customer> Customers { get; set; }

        DbSet<Film> Films { get; set; }

        DbSet<ShoppingCartMovie> ShoppingCartMovies { get; set; }

        DbSet<Sale> Sales { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}
