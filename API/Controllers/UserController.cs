using API.DTO;
using API.Helpers;
using API.Model;
using API.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public UserController(CulinaryContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return (await _context.Users
                .ToListAsync())
                .Select(ctg => (UserDto)ctg)
                .ToList();
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(c => c.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return (UserDto)user;
        }

        // PUT: api/user/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{ingId}")]
        public async Task<IActionResult> PutIngredent(int ingId, UserDto dto)
        {


            var ingDb = _context.Users
                .FirstOrDefault(ing => ingId == ing.Id)
                .CopyProperties(dto);

            ingDb.UpdatedAt = DateTime.Now;

            _context.Entry(ingDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(ingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/user
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto dto)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CompanyContext.Category'  is null.");
            }
            var User = (User)dto;

            User.CreatedAt = DateTime.Now;
            User.UpdatedAt = DateTime.Now;
            User.IsActive = true;
            User.PasswordHash = PasswordHelper.HashPassword(dto.PasswordHash);

            _context.Users.Add(User);
            await _context.SaveChangesAsync();


            return Ok(User);
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            User.IsActive = false;

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool UserExists(int id)
        {
            return (_context.Users?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}
