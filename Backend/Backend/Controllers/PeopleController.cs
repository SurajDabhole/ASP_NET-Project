using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                _context.People.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person); // returns 200 OK with the created person passed as object in the body
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
