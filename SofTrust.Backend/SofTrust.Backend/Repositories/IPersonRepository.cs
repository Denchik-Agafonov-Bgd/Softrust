using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersonEmailPhone(string email, string phone);

        void AddPerson(Person person);
    }
}
