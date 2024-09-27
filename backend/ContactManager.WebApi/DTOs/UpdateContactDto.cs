namespace ContactManager.WebApi.DTOs
{
    public class UpdateContactDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public bool IsMarried { get; set; }
    }
}