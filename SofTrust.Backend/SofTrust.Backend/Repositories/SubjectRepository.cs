using SofTrust.Backend.Data;
using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public class SubjectRepository: ISubjectRepository
    {
        protected DataContext _context;

        public SubjectRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAllSubject()
        {
            var subjects = (from s in _context.Subject
                            select new Subject
                            {
                                Id = s.Id,
                                Name = s.Name,
                            }).ToList();
            return subjects;
        }
    }
}
