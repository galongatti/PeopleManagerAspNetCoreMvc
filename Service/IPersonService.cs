using ManagerPeople.Models;

namespace ManagerPeople.Service;

public interface IPersonService
{
    Task<List<Person>> GetAll();
    
    Task<Person> Save(Person person);

    Task<Person?> GetByCpf(string cpf);
    
    Task<Person?> GetById(int id);
    
    Task<Person> Update(Person person);
    Task<Person> Delete(int id);
}