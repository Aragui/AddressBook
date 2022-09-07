namespace AddressBook.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> AddressLines { get; set; }
        public string Phone { get; set; }
       
    }
}
