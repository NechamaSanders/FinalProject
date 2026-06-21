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
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
        }
        public async Task<IngredientDto> CreateIngredientAsync(IngredientCreateDto dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);

            await _ingredientRepository.AddAsync(ingredient);
            await _ingredientRepository.SaveChangesAsync();

            return _mapper.Map<IngredientDto>(ingredient);
        }
    }
}
