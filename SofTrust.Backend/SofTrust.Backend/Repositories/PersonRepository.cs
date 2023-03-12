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

        public async Task<Person> GetPersonEmailPhone(string email, string phone)
        {
            return await (from p in _context.Person
                                where p.Email == email && p.Phone == phone
                                select new Person
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Phone = p.Phone,
                                    Email = p.Email,
                                }).FirstOrDefaultAsync();
        }

        public async Task<Person> AddPerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();

            return await (from pers in _context.Person
                          orderby pers.Id descending
                          select new Person
                          {
                              Id = pers.Id,
                              Name = pers.Name,
                              Email = pers.Email,
                              Phone = pers.Phone,
                              
                          }).FirstAsync();
        }


    }
}
