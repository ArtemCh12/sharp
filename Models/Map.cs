using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MapName { get; set; }
        public string Mode { get; set; }

    }
}
