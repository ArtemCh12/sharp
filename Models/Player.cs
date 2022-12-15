using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public string Rating{get; set;}


        [ForeignKey("Role_id")]
        public Role Role { get; set; }
        [DisplayName("Role")]
        public int Role_id { get; set; }

        [ForeignKey("Team_id")]
        public Team Team { get; set; }
        [DisplayName("Team")]
        public int Team_id { get; set; }



    }
}
