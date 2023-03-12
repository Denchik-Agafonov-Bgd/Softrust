using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonEmailPhone(string email, string phone);

        Task<Person> AddPerson(Person person);
    }
}
