using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rolename { get; set; }

    }
}
