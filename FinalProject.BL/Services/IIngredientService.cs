using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BL.DTOs;

namespace FinalProject.BL.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync();
        Task<IngredientDto> CreateIngredientAsync(string name);
    }
}
