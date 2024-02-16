using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Author entities from DB
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

    }
}
