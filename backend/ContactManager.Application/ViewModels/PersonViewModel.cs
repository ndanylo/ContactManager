namespace ContactManager.Application.ViewModels
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public bool isMarried { get; set; } 
        public string Phone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
