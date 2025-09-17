using ManagerPeople.Models;

namespace ManagerPeople.Repository;

public interface IPersonRepository
{
    Task<List<Person>> GetAll();
    Task<Person> Save(Person person);
}