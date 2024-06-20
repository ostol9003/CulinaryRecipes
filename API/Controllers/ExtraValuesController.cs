using API.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtraValuesController : ControllerBase
    {
        private readonly CulinaryContext _context;

        public ExtraValuesController(CulinaryContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        [Route("RecipesInCategory")]
        public async Task<ActionResult<int>> RecipesInCategory(int categoryId)
        {
            if (_context.Recipes == null || _context.RecipeCategory == null)
            {
                return Problem("Entity set 'CulinaryContext.Recipes' or 'CulinaryContext.RecipeCategories' is null.");
            }

            var count = await _context.RecipeCategory
                .Where(rc => rc.CategoryId == categoryId)
                .CountAsync();

            return count > 0 ? count : 0;
        }

     
        [HttpGet]
        [Route("RecipesWithIngredient")]
        public async Task<ActionResult<int>> RecipesWithIngredient(int ingredientId)
        {
            if (_context.Recipes == null || _context.RecipeIngredient == null)
            {
                return Problem("Entity set 'CulinaryContext.Recipes' or 'CulinaryContext.RecipeIngredients' is null.");
            }

            var count = await _context.RecipeIngredient
                .Where(ri => ri.IngredientId == ingredientId)
                .CountAsync();

            return count > 0 ? count : 0;
        }

      
        [HttpGet]
        [Route("AveragePrepTime")]
        public async Task<ActionResult<double>> AveragePrepTime()
        {
            try
            {
                if (_context.Recipes == null)
                {
                    return Problem("Entity set 'CulinaryContext.Recipes' is null.");
                }

                var averagePrepTime = await _context.Recipes
                    .Where(r => r.IsActive)
                    .AverageAsync(r => (double)(r.PrepTime + r.CookTime));

                return Ok(averagePrepTime > 0 ? averagePrepTime : 0);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }
        }

     
        [HttpGet]
        [Route("AveragePrepTimeInCategory")]
        public async Task<ActionResult<double>> AveragePrepTimeInCategory(int categoryId)
        {
            try
            {
                if (_context.Recipes == null || _context.RecipeCategory == null)
                {
                    return Problem("Entity set 'CulinaryContext.Recipes' or 'CulinaryContext.RecipeCategories' is null.");
                }

                var averagePrepTime = await _context.RecipeCategory
                        .Where(r => r.IsActive)
                    .Where(rc => rc.CategoryId == categoryId)
                    .Join(
                        _context.Recipes,
                        rc => rc.RecipeId,
                        r => r.Id,
                        (rc, r) => new { r.PrepTime, r.CookTime }
                    )
                    .AverageAsync(r => (double)(r.PrepTime + r.CookTime));

                return Ok(averagePrepTime > 0 ? averagePrepTime : 0);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }
        }
    }
}
