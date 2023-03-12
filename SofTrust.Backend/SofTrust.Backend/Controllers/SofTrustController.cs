using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SofTrust.Backend.Data;
using SofTrust.Backend.Models;
using SofTrust.Backend.Repositories;
using System.Diagnostics.Metrics;
using System.Reflection;

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
        public async Task<ActionResult<List<Subject>>> GetAllSubject()
        {
            return await _subjectRepository.GetAllSubject();
        }

        [HttpPost("CreateMessage")]
        public async Task<ActionResult<MessageInfo>> CreateMessage(Person person, int subjectId, string message)
        {
            Person newPerson = await _personRepository.GetPersonEmailPhone(person.Email, person.Phone);

            if (newPerson is null)
            {
                newPerson = await _personRepository.AddPerson(person);
            }

            return Ok(await _messageRepository.AddMessage(new Message(newPerson.Id, subjectId, message)));
        }
    }
}
