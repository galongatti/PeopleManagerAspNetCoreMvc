using ManagerPeople.Models;

namespace ManagerPeople.Repository;

public interface IPersonRepository
{
    Task<List<Person>> GetAll();
    Task<Person> Save(Person person);
    Task<Person> Update(Person person);
    Task<Person?> GetByCpf(string cpf);
    Task<Person> GetById(int id);
    Task<bool> Exists(int id);
    Task<Person> Delete(int id);

}