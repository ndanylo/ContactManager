using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Persistence.Read.Models
{
    public class PersonDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}