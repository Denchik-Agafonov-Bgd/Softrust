using Microsoft.EntityFrameworkCore;

namespace SofTrust.Backend.Models
{
    [Keyless]
    public class MessageInfo
    {
        
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;
    }
}
