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

        public async Task<MessageInfo> AddMessage(Message message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            var result = await (from mess in _context.Message
                                join pers in _context.Person on mess.PersonId equals pers.Id
                                join subj in _context.Subject on mess.SubjectId equals subj.Id
                                orderby mess.Id descending
                                select new MessageInfo
                                {
                                    Name = pers.Name,
                                    Email = pers.Email,
                                    Phone = pers.Phone,
                                    Subject = subj.Name,
                                    Message = mess.Name
                                }).FirstAsync();

            return result;
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

        public async Task<Message?> GetLastMessage()
        {
            return (await _context.Message.FindAsync(1));
        }
    }
}
