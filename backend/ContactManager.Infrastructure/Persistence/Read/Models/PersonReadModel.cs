using ContactManager.Domain.ValueObjects;

namespace ContactManager.Infrastructure.Persistence.Read.Models
{
    public class PersonReadModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public MarriageStatus MarriageStatus {get; set;}

        public string Phone { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}