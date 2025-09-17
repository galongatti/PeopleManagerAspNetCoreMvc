using ManagerPeople.Data;
using ManagerPeople.Models;
using ManagerPeople.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ManagerPeople.Repository;

public class PersonRepository(ManagerPeopleContext context) : IPersonRepository
{
    public async Task<List<Person>> GetAll()
    {
        var persons = await context.Person.ToListAsync();
        return persons;
    }

    public async Task<Person> Save(Person person)
    {
        EntityEntry<Person> personSaved = await context.Person.AddAsync(person);
        await context.SaveChangesAsync();
        return personSaved.Entity;
    }
}