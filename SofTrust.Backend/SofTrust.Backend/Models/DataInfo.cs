using Microsoft.EntityFrameworkCore;

namespace SofTrust.Backend.Models
{
    [Keyless]
    public class DataInfo
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public int SubjectId { get; set; }
        public string Message { get; set; } = String.Empty;
    }
}
