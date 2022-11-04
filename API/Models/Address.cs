namespace API.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual List<Customer>? Customers { get; set; }
    }
}