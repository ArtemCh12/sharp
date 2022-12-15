using Game.Data;
using Game.Models;
using Game.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Game.Controllers
{
    public class PlayerController : Controller
    {
        public readonly DataDbContext _db;

        public PlayerController(DataDbContext db)
        {
            _db = db;
        }


        [Authorize(Roles = "admin, moderator, user")]
        public IActionResult Index()
        {
            IEnumerable<Player> objList = _db.Players;

            foreach (var obj in objList)
            {
                obj.Role = _db.Roles.FirstOrDefault(u => u.Id == obj.Role_id);
                obj.Team = _db.Teams.FirstOrDefault(u => u.Id == obj.Team_id);

            }

            return View(objList);
        }

        // GET-Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            PlayerVM playerVM = new PlayerVM()
            {
                Player = new Player(),
                TDDRole = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Rolename,
                    Value = i.Id.ToString()
                }),
                TDDTeam = _db.Teams.Select(i => new SelectListItem
                {
                    Text = i.TeamName,
                    Value = i.Id.ToString()
                })
            };

            return View(playerVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(PlayerVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Players.Add(obj.Player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Players.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Players.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Players.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            PlayerVM playerVM = new PlayerVM()
            {
                Player = new Player(),
                TDDRole = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Rolename,
                    Value = i.Id.ToString()
                }),
                TDDTeam = _db.Teams.Select(i => new SelectListItem
                {
                    Text = i.TeamName,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            playerVM.Player = _db.Players.Find(id);
            if (playerVM.Player == null)
            {
                return NotFound();
            }
            return View(playerVM);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(PlayerVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Update(obj.Player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _db.Players.Include(b => b.Role).Include(c => c.Team)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);

        }
    }
}
