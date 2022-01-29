namespace VladMedrisWebApp.Models
{
    public class PublishingCompany
    {
        public int ID { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
