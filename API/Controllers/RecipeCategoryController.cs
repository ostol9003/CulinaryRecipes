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
    public class RecipeCategoryController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public RecipeCategoryController(CulinaryContext context)
        {
            _context = context;
        }

        // GET: api/recipecategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeCategoryDto>>> GetRecipeCategory()
        {
            if (_context.RecipeCategory == null)
            {
                return NotFound();
            }

            return (await _context.RecipeCategory
                .Include(rc => rc.Recipe)
                .Include(rc => rc.Category)
                .Where(rc => rc.IsActive).ToListAsync())
                .Select(rc => (RecipeCategoryDto)rc)
                .ToList();
        }

        // GET: api/recipecategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeCategoryDto>> GetRecipeCategory(int id)
        {
            if (_context.RecipeCategory == null)
            {
                return NotFound();
            }

            var recipeCategory = await _context.RecipeCategory
                .Include(rc => rc.Recipe)
                .Include(rc => rc.Category)
                .FirstOrDefaultAsync(rc => rc.Id == id);

            if (recipeCategory == null)
            {
                return NotFound();
            }

            return (RecipeCategoryDto)recipeCategory;
        }

        // PUT: api/recipecategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeCategory(int id, RecipeCategoryDto dto)
        {
    
            var recipeCategoryDb = _context.RecipeCategory.FirstOrDefault(rc => rc.Id == id);
            if (recipeCategoryDb == null)
            {
                return NotFound();
            }

            recipeCategoryDb.CopyProperties(dto);
            recipeCategoryDb.UpdatedAt = DateTime.Now;

            _context.Entry(recipeCategoryDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeCategoryExists(id))
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

        // POST: api/recipecategory
        [HttpPost]
        public async Task<ActionResult<RecipeCategoryDto>> PostRecipeCategory(RecipeCategoryDto dto)
        {
            if (_context.RecipeCategory == null)
            {
                return Problem("Entity set 'CulinaryContext.RecipeCategory' is null.");
            }

            var recipeCategory = (RecipeCategory)dto;

            recipeCategory.CreatedAt = DateTime.Now;
            recipeCategory.UpdatedAt = DateTime.Now;
            recipeCategory.IsActive = true;

            _context.RecipeCategory.Add(recipeCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeCategory), new { id = recipeCategory.Id }, (RecipeCategoryDto)recipeCategory);
        }

        // DELETE: api/recipecategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            if (_context.RecipeCategory == null)
            {
                return NotFound();
            }

            var recipeCategory = await _context.RecipeCategory.FindAsync(id);
            if (recipeCategory == null)
            {
                return NotFound();
            }

            recipeCategory.IsActive = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeCategoryExists(int id)
        {
            return (_context.RecipeCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
