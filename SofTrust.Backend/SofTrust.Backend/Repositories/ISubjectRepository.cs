using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubject();
    }
}
