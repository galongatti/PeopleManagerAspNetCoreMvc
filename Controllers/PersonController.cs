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
            TempData["ErrorMessage"] = "Invalid data";
            return View(person);
        }

        try
        {
            _ = await _personService.Save(person);
            TempData["SuccessMessage"] = "Person created successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Error creating person";
            return View(person);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        try
        {       
            Person? person = await _personService.GetById(id);

            if (person != null) return View(person);
            TempData["ErrorMessage"] = "Person not found";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Person person)
    {

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Invalid data";
            return View(person);
        }
        
        try
        {
            _ = await _personService.Update(person);
            TempData["SuccessMessage"] = "Person updated successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Error updating person";
            return View(person);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        try
        {       
            Person? person = await _personService.GetById(id);

            if (person != null) return View(person);
            TempData["ErrorMessage"] = "Person not found";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Error retrieving person details";
            return RedirectToAction("Index");
        }
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {       
            Person? person = await _personService.GetById(id);

            if (person != null) return View(person);
            TempData["ErrorMessage"] = "Person not found";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Error retrieving person details";
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _personService.Delete(id);
            TempData["SuccessMessage"] = "Person deleted successfully!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Error deleting person";
            return RedirectToAction("Index");
        }
    }
    
    
}