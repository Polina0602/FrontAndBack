using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBack.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please, enter a valid email, example@example.com")]

        public string Email { get; set; }
        
        public string? PhotoPath { get; set; }

        public Role? Role { get; set; }

    }
}
