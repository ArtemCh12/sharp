using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models.ViewModels
{
    public class PlayerVM
    {
        public Player Player { get; set; }
        public IEnumerable<SelectListItem> TDDRole { get; set; }
        public IEnumerable<SelectListItem> TDDTeam { get; set; }
    
    }
}
