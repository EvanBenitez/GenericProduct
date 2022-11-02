namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? email { get; set; }
        public virtual Address? Address { get; set; }
    }
}