using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public StudentsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lstStudents = await _context.Student.ToListAsync();
                return Ok(lstStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var lstStudents = await _context.Student.Where(u => u.Id == id).ToListAsync();
                return Ok(lstStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Students students)
        {
            try
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Students students)
        {
            try
            {
                if (id != students.Id)
                {
                    return NotFound();
                }
                else
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "El estudiante fue actualizado con exito" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var student = await _context.Student.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Student.Remove(student);
                    await _context.SaveChangesAsync();
                    return Ok(new { messaje = "El estudiante fue eliminado con exito" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
