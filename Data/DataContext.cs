using first_web_api.Models;
using Microsoft.EntityFrameworkCore;
using models.first_web_api;

namespace first_web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "COOL", Damage = 30 },
                new Skill { Id = 2, Name = "Good", Damage = 50 },
                new Skill { Id = 3, Name = "Nice", Damage = 80 }


                );
        }
    }
}
