using API.DTO;
using API.Helpers;
using API.Model;
using API.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public RecipeIngredientController(CulinaryContext context)
        {
            _context = context;
        }

        // GET: api/recipeingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeIngredientDto>>> GetRecipeIngredient()
        {
            if (_context.RecipeIngredient == null)
            {
                return NotFound();
            }

            return (await _context.RecipeIngredient
                .Include(ri => ri.Recipe)
                .Include(ri => ri.Ingredient)
                .Where(ri => ri.IsActive).ToListAsync())
                .Select(ri => (RecipeIngredientDto)ri)
                .ToList();
        }

        // GET: api/recipeingredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeIngredientDto>> GetRecipeIngredient(int id)
        {
            if (_context.RecipeIngredient == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredient
                .Include(ri => ri.Recipe)
                .Include(ri => ri.Ingredient)
                .FirstOrDefaultAsync(ri => ri.Id == id);

            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return (RecipeIngredientDto)recipeIngredient;
        }

       

        // PUT: api/recipeingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeIngredient(int id, RecipeIngredientDto dto)
        {

            var recipeIngredientDb = _context.RecipeIngredient.FirstOrDefault(ri => ri.Id == id);
            if (recipeIngredientDb == null)
            {
                return NotFound();
            }

            recipeIngredientDb.CopyProperties(dto);
            recipeIngredientDb.UpdatedAt = DateTime.Now;

            _context.Entry(recipeIngredientDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/recipeingredient
        [HttpPost]
        public async Task<ActionResult<RecipeIngredientDto>> PostRecipeIngredient(RecipeIngredientDto dto)
        {
            if (_context.RecipeIngredient == null)
            {
                return Problem("Entity set 'CulinaryContext.RecipeIngredient' is null.");
            }

            var recipeIngredient = (RecipeIngredient)dto;

            recipeIngredient.CreatedAt = DateTime.Now;
            recipeIngredient.UpdatedAt = DateTime.Now;
            recipeIngredient.IsActive = true;

            _context.RecipeIngredient.Add(recipeIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeIngredient), new { id = recipeIngredient.Id }, (RecipeIngredientDto)recipeIngredient);
        }

        // DELETE: api/recipeingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeIngredient(int id)
        {
            if (_context.RecipeIngredient == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredient.FindAsync(id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            recipeIngredient.IsActive = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeIngredientExists(int id)
        {
            return (_context.RecipeIngredient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
