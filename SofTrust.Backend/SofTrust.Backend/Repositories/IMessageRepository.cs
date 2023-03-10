using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessage();
        void AddMessage(Message message);

        IEnumerable<MessageInfo> GetLastMessage();
    }
}
