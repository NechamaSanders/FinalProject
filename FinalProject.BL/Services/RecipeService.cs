using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.BL.DTOs;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Repositories;

namespace FinalProject.BL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RecipeDto>>(recipes);
        }

        public async Task<RecipeDto> GetRecipeByIdAsync(int id)
        {
            var r = await _recipeRepository.GetByIdAsync(id);
            if (r == null) return null;

            return _mapper.Map<RecipeDto>(r);
        }
    

        public async Task<RecipeDto> CreateRecipeAsync(RecipeCreateDto dto)
        {
            var recipe = new Recipe
            {
                Title = dto.Title,
                Instructions = dto.Instructions,
                PrepTimeMinutes = dto.PrepTimeMinutes,
                UserId = dto.UserId,
                RecipeIngredients = new List<RecipeIngredient>()
            };

            if (dto.Ingredients != null)
            {
                foreach (var ingredient in dto.Ingredients)
                {
                    recipe.RecipeIngredients.Add(new RecipeIngredient
                    {
                        IngredientId = ingredient.IngredientId,
                        Amount = ingredient.Amount 
                    });
                }
            }

            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveChangesAsync();

            return _mapper.Map<RecipeDto>(recipe);
        }

        public async Task<bool> UpdateRecipeAsync(int id, RecipeCreateDto dto)
        {
            var existingRecipe = await _recipeRepository.GetByIdAsync(id);
            if (existingRecipe == null) return false;

            _mapper.Map(dto, existingRecipe);

            existingRecipe.RecipeIngredients.Clear();
            if (dto.Ingredients != null)
            {
                foreach (var item in dto.Ingredients)
                {
                    existingRecipe.RecipeIngredients.Add(new RecipeIngredient
                    {
                        IngredientId = item.IngredientId,
                        Amount = item.Amount
                    });
                }
            }

            _recipeRepository.Update(existingRecipe);
            await _recipeRepository.SaveChangesAsync();
            return true;
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