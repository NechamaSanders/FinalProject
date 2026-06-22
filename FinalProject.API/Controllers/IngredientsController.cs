using FinalProject.BL.DTOs;
using FinalProject.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetAll()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IngredientCreateDto ingredientDto)
        {
            await _ingredientService.CreateIngredientAsync(ingredientDto);
            return StatusCode(201);
        }
    }
}