using Microsoft.AspNetCore.Mvc;
using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessage();
        Task<MessageInfo> AddMessage(Message message);

        Task<Message> GetLastMessage();
    }
}
