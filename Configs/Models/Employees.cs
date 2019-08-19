using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Configs.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
       //REGULAR EXPRESSION  [ErrorMessage="Is required value"]

        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public Dept Department { get; set; }

        
        public string PhotoPath { get; set; }
        





    }
}
