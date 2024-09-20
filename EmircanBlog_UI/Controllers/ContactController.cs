
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmircanBlog_UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(ContactDto contactEntity)
        {

            if (ModelState.IsValid)
            {
                await _contactService.AddAsyncService(contactEntity);
                return RedirectToAction("Index", "Contact");
            }

            else
            {
                throw new Exception("Hata");
            }
            
           
        }
    }
}
