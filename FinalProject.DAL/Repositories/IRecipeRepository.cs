using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> GetByIdAsync(int id);
        Task AddAsync(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(Recipe recipe);
        Task<bool> SaveChangesAsync();
    }
}
