using first_web_api.Models;
using Microsoft.EntityFrameworkCore;
using models.first_web_api;

namespace first_web_api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
