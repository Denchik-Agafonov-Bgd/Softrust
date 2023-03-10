using Microsoft.EntityFrameworkCore;
using SofTrust.Backend.Data;
using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        protected DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPersonEmailPhone(string email, string phone)
        {
            var person = (from p in _context.Person
                          where p.Email == email && p.Phone == phone
                          select new Person
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Phone = p.Phone,
                              Email = p.Email,
                          });

            return person;

            //var person2 = _context.Person.Where(x => x.Email == email && x.Phone == phone).Select(x=> new Person { });
        }

        public void AddPerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }


    }
}
