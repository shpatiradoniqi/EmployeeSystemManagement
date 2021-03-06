using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class Employee{

        public int Id { get; set; }

        [Required,MaxLength(50,ErrorMessage ="Te jete me e vogel se 50")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage="Invalid format of email")]
        public string Email { get; set; }

        [Required]
        public Dept? Departament { get; set; }

        public string PhotoPath { get; set; }

    }
}
