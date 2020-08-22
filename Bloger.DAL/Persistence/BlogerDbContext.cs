using Bloger.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Bloger.DAL.Persistence
{
    public class BlogerDbContext : DbContext
    {
    
        
        public DbSet<Category> Category { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; } 
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Coments> Coments { get; set; }
        public DbSet<Post_Category> Post_Category { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseSqlServer("Server=RENATO-PC\\SQLEXPRESS;Database=BlogerDb;Trusted_Connection=True;MultipleActiveResultSets=true", x => x.MigrationsAssembly("Bloger.DAL"));
        }
    }
}