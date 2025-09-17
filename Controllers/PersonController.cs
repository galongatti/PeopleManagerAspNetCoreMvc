using ManagerPeople.Models;
using ManagerPeople.Service;
using Microsoft.AspNetCore.Mvc;

namespace ManagerPeople.Controllers;

public class PersonController : Controller
{
    
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> Index()
    {
        List<Person> allUsers = await _personService.GetAll();
        return View(allUsers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View(person);
        }

        _ = await _personService.Save(person);
        return RedirectToAction("Index");
    }
}