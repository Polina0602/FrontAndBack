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
        [MaxLength(50), MinLength(5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please, enter a valid email, example@example.com")]
        [MaxLength(50)]
        public string Email { get; set; }
        
        public string? PhotoPath { get; set; }

        public Role? Role { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
