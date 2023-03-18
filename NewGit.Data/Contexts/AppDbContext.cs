using Microsoft.EntityFrameworkCore;
using NewGit.Domain.Entities;

namespace NewGit.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Progects { get; set; }
        public DbSet<Organisation> Organisations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\mssqllocaldb;Database=MyNewGit;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}
