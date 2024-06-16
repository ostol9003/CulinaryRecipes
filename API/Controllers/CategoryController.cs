using API.DTO;
using API.Helpers;
using API.Model;
using API.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public CategoryController(CulinaryContext context) 
        {
            _context=context;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return (await _context.Categories
                .Include(c => c.Recipes)
                .Where(c=> c.IsActive == true).ToListAsync())
                .Select(ctg => (CategoryDto) ctg)
                .ToList();
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories
                .Include(c => c.Recipes)
                .ThenInclude(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return (CategoryDto)category;
        }

        // PUT: api/category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{catId}")]
        public async Task<IActionResult> PutCatgory(int catId, CategoryDto dto)
        {
        

            var catDb = _context.Categories
                .FirstOrDefault(cli => catId == cli.Id)
                .CopyProperties(dto);

            catDb.UpdatedAt = DateTime.Now;
            
            _context.Entry(catDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(catId))
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

        // POST: api/category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto dto)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'CompanyContext.Clients'  is null.");
            }
            var category = (Category)dto;

            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            category.IsActive = true;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

           
            return Ok(category);
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsActive = false;

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}
