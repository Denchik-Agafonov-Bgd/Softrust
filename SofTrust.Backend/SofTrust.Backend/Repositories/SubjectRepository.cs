using Microsoft.EntityFrameworkCore;
using SofTrust.Backend.Data;
using SofTrust.Backend.Models;
using System.Collections.Generic;

namespace SofTrust.Backend.Repositories
{
    public class SubjectRepository: ISubjectRepository
    {
        protected DataContext _context;

        public SubjectRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Subject>> GetAllSubject()
        {
            return await (from s in _context.Subject
                                  select new Subject
                                  {
                                      Id = s.Id,
                                      Name = s.Name,
                                  }).ToListAsync();
        }
    }
}
