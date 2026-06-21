using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Specialty { get; set; } 
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
