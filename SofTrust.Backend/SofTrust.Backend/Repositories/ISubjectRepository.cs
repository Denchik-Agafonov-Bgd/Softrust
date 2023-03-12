using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubject();
    }
}
