using ManagerPeople.Models;
using ManagerPeople.Repository;

namespace ManagerPeople.Service;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public async Task<List<Person>> GetAll()
    {
        return await personRepository.GetAll();
    }

    public async Task<Person> Save(Person person)
    {
        return await personRepository.Save(person);
    }
}