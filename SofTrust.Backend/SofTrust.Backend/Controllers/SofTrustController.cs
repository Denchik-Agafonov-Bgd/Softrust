using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SofTrust.Backend.Data;
using SofTrust.Backend.Models;
using SofTrust.Backend.Repositories;
using System.Diagnostics.Metrics;

namespace SofTrust.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SofTrustController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IPersonRepository _personRepository;

        public SofTrustController(DataContext context, ISubjectRepository subjectRepository, IMessageRepository messageRepository, IPersonRepository personRepository)
        {
            _context = context;
            _subjectRepository = subjectRepository;
            _messageRepository = messageRepository;
            _personRepository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Subject> GetAllSubject()
        {
            return _subjectRepository.GetAllSubject().ToList();
        }

        [HttpPost("CreateMessage")]
        public void CreateMessage(Person person, int subjectId, string message)
        {
            Person personNew = _personRepository.GetPersonEmailPhone(person.Email, person.Phone).FirstOrDefault();

            if (personNew is null)
            {
                _personRepository.AddPerson(person);
                personNew = _personRepository.GetPersonEmailPhone(person.Email, person.Phone).First();
            }

            _messageRepository.AddMessage(new Message(personNew.Id, subjectId, message));

        }

        [HttpGet("Output")]
        public MessageInfo GetLastMessage()
        {
            return _messageRepository.GetLastMessage().Last();
        }


    }
}
