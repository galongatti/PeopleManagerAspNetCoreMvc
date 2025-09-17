using ManagerPeople.Models;

namespace ManagerPeople.Service;

public interface IPersonService
{
    Task<List<Person>> GetAll();
    
    Task<Person> Save(Person person);
}