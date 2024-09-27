using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Persistence.Read.Models
{
    public class PersonReadModelDbContext: DbContext
    {
        public DbSet<PersonReadModel> People { get; set; }

        public PersonReadModelDbContext(DbContextOptions<PersonReadModelDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}