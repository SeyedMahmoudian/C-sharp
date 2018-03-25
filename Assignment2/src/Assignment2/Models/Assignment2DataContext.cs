using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Assignment2DataContext : DbContext
    {
        public Assignment2DataContext(DbContextOptions<Assignment2DataContext> options)
              : base(options)
        {

        }
        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BadWords> BadWords { get; set; }

        public DbSet<Photos> Photos { get; set; }
    }
}
