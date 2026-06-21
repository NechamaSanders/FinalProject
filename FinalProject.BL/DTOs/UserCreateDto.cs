using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; } // מותאם ל-DAL
    }
}
