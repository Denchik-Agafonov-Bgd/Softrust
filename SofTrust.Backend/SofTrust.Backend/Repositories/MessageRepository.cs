using Microsoft.EntityFrameworkCore;
using SofTrust.Backend.Data;
using SofTrust.Backend.Models;

namespace SofTrust.Backend.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        protected DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {
            _context.Message.Add(message);
            _context.SaveChanges();
        }

        public IEnumerable<Message> GetAllMessage()
        {
            var messages = (from m in _context.Message
                            select new Message
                            {
                                PersonId = m.PersonId,
                                SubjectId = m.SubjectId,
                                Name = m.Name
                            }).ToList();
            return messages;
        }

        public IEnumerable<MessageInfo> GetLastMessage()
        {
            var messages = (from m in _context.Message
                            join p in _context.Person on m.PersonId equals p.Id
                            join s in _context.Subject on m.SubjectId equals s.Id
                            select new MessageInfo
                            {
                                Name = p.Name,
                                Email = p.Email,
                                Phone = p.Phone,
                                Subject = s.Name,
                                Message = m.Name
                            }).ToList();

            return messages;

        }
    }
}
