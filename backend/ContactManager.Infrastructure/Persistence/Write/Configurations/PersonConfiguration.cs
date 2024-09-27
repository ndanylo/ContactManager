using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContactManager.Infrastructure.Persistence.Write.ValueConverters;
using ContactManager.Domain.Entities;
using ContactManager.Domain.ValueObjects;

namespace ContactManager.Infrastructure.Persistence.Read.Models
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasConversion(new NameConverter())
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(p => p.Birthday)
                .HasConversion(new BirthdayConverter())
                .HasColumnName("Birthday")
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasConversion(new PhoneConverter())
                .HasColumnName("Phone")
                .IsRequired();

            builder.Property(p => p.Salary)
                .HasConversion(new SalaryConverter())
                .HasColumnName("Salary")
                .IsRequired();
        }
    }
}