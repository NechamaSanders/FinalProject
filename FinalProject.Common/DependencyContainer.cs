using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FinalProject.BL.Services;
using FinalProject.BL;
using FinalProject.DAL;
using FinalProject.DAL.Repositories;
namespace FinalProject.Common
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterSystemServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIngredientService, IngredientService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FinalProject.DAL.AppDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}