using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return CreatedAtRoute("GetPerson", new { id = person.Id }, person); // returns 201 Created with the person passed as object in the body, also location of the resource(http://localhost:3000/api/People/{id})
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/People
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            try
            {
                var people = await _context.People.ToListAsync();
                return Ok(people); // returns 200 OK with the list of people passed as object in the body
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/People/5
        [HttpGet("{id:int}", Name = "GetPerson")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                var person = await _context.People.FindAsync(id);

                if (person is null)
                {
                    return NotFound(); // returns 404 Not Found if the person with the specified id does not exist
                }

                return Ok(person); // returns 200 OK with the person passed as object in the body
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // put: api/People/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            try
            {
                if (id != person.Id)
                {
                    return BadRequest("Person ID mismatch"); // returns 400 Bad Request if the id in the URL does not match the id in the body
                }

                if (!await _context.People.AnyAsync(p => p.Id == id))
                {
                    return NotFound(); // returns 404 Not Found if the person with the specified id does not exist
                }

                _context.People.Update(person);
                await _context.SaveChangesAsync();
                return NoContent(); // returns 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // DELETE: api/People/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var person = await _context.People.FindAsync(id);

                if (person is null)
                {
                    return NotFound(); // returns 404 Not Found if the person with the specified id does not exist
                }

                _context.People.Remove(person);
                await _context.SaveChangesAsync();
                //return Ok(person); // returns 200 OK with the deleted person passed as object in the body
                return NoContent(); // returns 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}



