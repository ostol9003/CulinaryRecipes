using API.DTO;
using API.Helpers;
using API.Model;
using API.Model.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly CulinaryContext _context;
        private readonly IMapper _mapper;

        public RecipeController(CulinaryContext context, IMapper mapper) 
        {
            _context=context;
            _mapper = mapper;
        }

        // GET: api/Recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipe()
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipes = await _context.Recipes
                .Where(r => r.IsActive)
                .Include(r => r.Categories)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            return _mapper.Map<List<RecipeDto>>(recipes);

        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes
                .Where(r => r.IsActive && r.Id == id)
                .Include(r => r.Categories)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync();

            if (recipe == null)
            {
                return NotFound();
            }

            return _mapper.Map<RecipeDto>(recipe);
        }

        // PUT: api/Recipe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{recId}")]
        public async Task<IActionResult> PutRecipe(int recId, RecipeDto dto)
        {
            if (recId != dto.Id)
            {
                return BadRequest();
            }

            var recDb = _context.Recipes
                .FirstOrDefault(cli => recId == cli.Id)
                .CopyProperties(dto);

            recDb.UpdatedAt = DateTime.Now;
            
            _context.Entry(recDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(recId))
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

        // POST: api/Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeDto>> PostRecipe(RecipeDto dto)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'CompanyContext.Recipe'  is null.");
            }
            var recipe = (Recipe)dto;

            recipe.CreatedAt = DateTime.Now;
            recipe.UpdatedAt = DateTime.Now;
            recipe.IsActive = true;

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

           
            return Ok(recipe);
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipe.IsActive = false;

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool RecipeExists(int id)
        {
            return (_context.Recipes?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}
