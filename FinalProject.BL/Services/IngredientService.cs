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
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return ingredients.Select(i => new IngredientDto { Id = i.Id, Name = i.Name });
        }
        public async Task<IngredientDto> CreateIngredientAsync(string name)
        {
            var ingredient = new Ingredient { Name = name };
            await _ingredientRepository.AddAsync(ingredient);
            await _ingredientRepository.SaveChangesAsync();

            return new IngredientDto { Id = ingredient.Id, Name = ingredient.Name };
        }
    }
}
