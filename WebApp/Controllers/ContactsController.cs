using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entities;
using WebApp.Services;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    #region constructors & private fields

    private readonly ContactService _contactService;

    public ContactsController(ContactService contactService)
    {
        _contactService = contactService;
    }

    #endregion


    public IActionResult Index()
    {
        ViewData["Title"] = "Contact us";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactEntity contactEntity)
    {
        if (ModelState.IsValid)
        {
            var contact = await _contactService.CreateAsync(contactEntity);
            if (contact != null)
            {


                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong when trying to send your message");
        }

        return View(contactEntity);
    }
}
