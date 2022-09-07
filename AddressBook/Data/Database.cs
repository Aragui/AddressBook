using System.Text.Json;

using AddressBook.Models;

namespace AddressBook.Data
{
    public class Database
    {
        JsonSerializerOptions options;
        List<Contact> contacts;

        public Database()
        {
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = File.ReadAllText(@"Data\fakedatabase.json");

            contacts = JsonSerializer.Deserialize<List<Contact>>(json, options);

        }

        public List<Contact> GetContacts() => contacts.OrderBy(contact => contact.Name).ToList();

        public List<Contact> Search(string phrase) => contacts.OrderBy(contact => contact.Name)
                                                        .Where(contact => contact.Name.ToLower().Contains(phrase.ToLower())).ToList();

        public bool Delete(string id)
        {

            if (contacts.Contains(contacts.FirstOrDefault(contact => contact.Id.Equals(id))))
            {
                var newContacts = contacts.Where(contact => !contact.Id.Equals(id)).ToList();
                File.WriteAllText(@"Data\fakedatabase.json", 
                                        JsonSerializer.Serialize(newContacts, options));
                
                return true;
            }

            return false;

        }
    }
}
