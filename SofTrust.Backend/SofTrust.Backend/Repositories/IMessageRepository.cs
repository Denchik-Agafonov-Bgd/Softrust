using Microsoft.AspNetCore.Mvc;
using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllMessage();
        Task<MessageInfo> AddMessage(Message message);
    }
}
