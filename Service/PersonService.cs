using ManagerPeople.Models;
using ManagerPeople.Repository;

namespace ManagerPeople.Service;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public async Task<List<Person>> GetAll()
    {
        return await personRepository.GetAll();
    }

    public async Task<Person?> GetByCpf(string cpf)
    {
        return await personRepository.GetByCpf(cpf);
    }

    public async Task<Person> GetById(int id)
    {
        return await personRepository.GetById(id);
    }

    public async Task<Person> Update(Person person)
    {
        bool exists = await personRepository.Exists(person.Id);
        if(!exists)
            throw new Exception("Person not found");
        
        return await personRepository.Update(person);
    }

    public async Task<Person> Save(Person person)
    {
        Person? cpfExist = await GetByCpf(person.CPF);
        
        if(cpfExist != null)
            throw new Exception("CPF already exists");
        
        return await personRepository.Save(person);
    }
    
    public async Task<Person> Delete(int id)
    {
        bool exists = await personRepository.Exists(id);
        if(!exists)
            throw new Exception("Person not found");
        
        return await personRepository.Delete(id);
    }
}