using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignUpBackend.Model;
using SignUpBackend.DatabaseSQL;

namespace SignUpBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD : Controller
    {
        private readonly ApplicationDbContext _context;

        public CRUD(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person person)
        {
            var data = _context.Person.FirstOrDefault(p => p.Id == person.Id);
            data.FirstName = person.FirstName;
            data.LastName = person.LastName;
            data.Email = person.Email;
            data.Password = person.Password;
            await _context.SaveChangesAsync();
            return person;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> Get(Person person)
        {
            var data = await _context.Person.FindAsync(person.Id);
            return data;
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> Delete(Person person)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
