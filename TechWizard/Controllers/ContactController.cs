using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWizard.Business.ViewModels.DTOs;

namespace TechWizard.Controllers
{
    
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(ContactDTO form)
        {
            if(ModelState.IsValid)
            {
                TempData["email"] = form.Email;
                return RedirectToAction("MessageSent");
            }
            return View(form);
        }

        public IActionResult MessageSent()
        {
            if (TempData["email"] != null)
            {
                var contactDTO = new ContactDTO()
                {
                    Message = $"Thank you for contacting us, we gonna reply you lightning fast on '{TempData["email"]}'."
                };
                return View(contactDTO);
            }
            return RedirectToAction("Index");
        }
    }
}
