using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Weaponname { get; set; }
        public string Damage { get; set; }
        public string Price { get; set; }
    }
}
