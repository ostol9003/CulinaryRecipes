using API.DTO;
using API.Helpers;
using API.Model;
using API.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public IngredientController(CulinaryContext context) 
        {
            _context=context;
        }

        // GET: api/ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients()
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            return (await _context.Ingredients
                .Where(c=> c.IsActive == true).ToListAsync())
                .Select(ctg => (IngredientDto) ctg)
                .ToList();
        }

        // GET: api/ingredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> GetIngredient(int id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(c => c.Id == id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return (IngredientDto)ingredient;
        }

        // PUT: api/category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{ingId}")]
        public async Task<IActionResult> PutIngredent(int ingId, IngredientDto dto)
        {
        

            var ingDb = _context.Ingredients
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
                if (!IngredientExists(ingId))
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
        public async Task<ActionResult<IngredientDto>> PostIngedient(IngredientDto dto)
        {
            if (_context.Ingredients == null)
            {
                return Problem("Entity set 'CompanyContext.Clients'  is null.");
            }
            var ingredient = (Ingredient)dto;

            ingredient.CreatedAt = DateTime.Now;
            ingredient.UpdatedAt = DateTime.Now;
            ingredient.IsActive = true;

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

           
            return Ok(ingredient);
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredent(int id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            ingredient.IsActive = false;

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool IngredientExists(int id)
        {
            return (_context.Categories?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}
