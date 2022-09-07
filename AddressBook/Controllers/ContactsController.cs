using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        Database db = new Database();

        [HttpGet]
        public List<Contact> Index(string? phrase) => phrase == null ? db.GetContacts() : db.Search(phrase);

        [Route("{id}")]
        [HttpGet]
        public IActionResult FromId(string id)
        {
            var contact = db.GetContacts().FirstOrDefault(contact => contact.Id == id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(string id) => db.Delete(id) ? NoContent() : BadRequest();

    }
}
