using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BL.DTOs;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Repositories;

namespace FinalProject.BL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return recipes.Select(r => new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                Instructions = r.Instructions,
                PrepTimeMinutes = r.PrepTimeMinutes,
                UserId = r.UserId,
                UserName = r.User != null ? r.User.Name : "Unknown",
                Ingredients = r.RecipeIngredients != null
                    ? r.RecipeIngredients.Select(ri => ri.Ingredient != null ? ri.Ingredient.Name : "Unknown").ToList()
                    : new List<string>()
            });
        }

        public async Task<RecipeDto> GetRecipeByIdAsync(int id)
        {
            var r = await _recipeRepository.GetByIdAsync(id);
            if (r == null) return null;

            return new RecipeDto
            {
                Id = r.Id,
                Title = r.Title,
                Instructions = r.Instructions,
                PrepTimeMinutes = r.PrepTimeMinutes,
                UserId = r.UserId,
                UserName = r.User != null ? r.User.Name : "Unknown",
                Ingredients = r.RecipeIngredients != null
                    ? r.RecipeIngredients.Select(ri => ri.Ingredient != null ? ri.Ingredient.Name : "Unknown").ToList()
                    : new List<string>()
            };
        }

        public async Task<RecipeDto> CreateRecipeAsync(RecipeCreateDto dto)
        {
            var recipe = new Recipe
            {
                Title = dto.Title,
                Instructions = dto.Instructions,
                PrepTimeMinutes = dto.PrepTimeMinutes,
                UserId = dto.UserId
            };

            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveChangesAsync();

            return new RecipeDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Instructions = recipe.Instructions,
                PrepTimeMinutes = recipe.PrepTimeMinutes,
                UserId = recipe.UserId
            };
        }
        public async Task<bool> UpdateRecipeAsync(int id, RecipeCreateDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return false;
            recipe.Title = dto.Title;
            recipe.Instructions = dto.Instructions;
            recipe.PrepTimeMinutes = dto.PrepTimeMinutes;
            recipe.UserId = dto.UserId;
            _recipeRepository.Update(recipe);
            return await _recipeRepository.SaveChangesAsync();
        }
        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return false;

            _recipeRepository.Delete(recipe);
            return await _recipeRepository.SaveChangesAsync();
        }
    }
}