using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL.DTOs
{
    public class RecipeCreateDto
    {
        public string Title { get; set; }
        public string Instructions { get; set; }
        public int PrepTimeMinutes { get; set; }
        public int UserId { get; set; }
    }
}