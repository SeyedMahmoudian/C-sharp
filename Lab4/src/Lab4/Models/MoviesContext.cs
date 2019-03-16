using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab4.Models
{
    public class MoviesContext : DbContext
    {
       public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
