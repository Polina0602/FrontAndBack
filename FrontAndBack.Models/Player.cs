using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBack.Models
{
    public class Player
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Role? Role { get; set; }

    }
}
