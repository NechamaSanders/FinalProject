using FinalProject.BL.DTOs;
using FinalProject.BL.Services;
using Microsoft.AspNetCore.Mvc;
namespace FinalProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAll()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetById(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound();
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RecipeCreateDto recipeDto)
        {
            RecipeDto createdRecipe = await _recipeService.CreateRecipeAsync(recipeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdRecipe.Id }, recipeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RecipeCreateDto recipeDto)
        {
            var success = await _recipeService.UpdateRecipeAsync(id, recipeDto);
            if (!success) return NotFound(new { message = "Recipe not found" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _recipeService.DeleteRecipeAsync(id);
            if (!success) return NotFound(new { message = "Recipe not found" });

            return NoContent();
        }
    }
}