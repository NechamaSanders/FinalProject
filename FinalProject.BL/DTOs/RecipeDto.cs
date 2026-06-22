using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public int PrepTimeMinutes { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
    }
}
