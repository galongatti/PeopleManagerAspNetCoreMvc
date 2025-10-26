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
        List<Person> persons = await context.Person.AsNoTracking().ToListAsync();
        return persons;
    }

    public async Task<Person> Save(Person person)
    {
        EntityEntry<Person> personSaved = await context.Person.AddAsync(person);
        await context.SaveChangesAsync();
        return personSaved.Entity;
    }

    public async Task<Person> Update(Person person)
    {
        EntityEntry<Person> res = context.Person.Update(person);
        await context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<Person?> GetByCpf(string cpf)
    {
        Person? person = await (from p in context.Person.AsNoTracking()
            where p.CPF == cpf
            select p).FirstOrDefaultAsync();
        return person;
    }

    public async Task<Person> GetById(int id)
    {
        Person person = await context.Person.AsNoTracking().FirstAsync(p => p.Id == id) ?? throw new Exception("Person not found");
        return person;
    }

    public async Task<bool> Exists(int id)
    {
        return await context.Person.AsNoTracking().AnyAsync(p => p.Id == id);
    }

    public async Task<Person> Delete(int id)
    {
  
        
        EntityEntry<Person> res = context.Person.Remove(new Person { Id = id });
        await context.SaveChangesAsync();
        return res.Entity;
    }
}