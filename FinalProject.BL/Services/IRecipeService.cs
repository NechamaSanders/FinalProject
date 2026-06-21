using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BL.DTOs;

namespace FinalProject.BL.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        Task<RecipeDto> GetRecipeByIdAsync(int id);
        Task<RecipeDto> CreateRecipeAsync(RecipeCreateDto recipeDto);
        Task<bool> UpdateRecipeAsync(int id, RecipeCreateDto recipeDto);
        Task<bool> DeleteRecipeAsync(int id);
    }
}
