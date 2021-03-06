using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(l => l.Sport != ("Football"))
                .ToList();
            ViewBag.Conferences = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.DallasTeams = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            ViewBag.TTeams = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();
            ViewBag.AllTeams = _context.Teams
                .OrderBy(t => t.Location)
                .ToList();
            ViewBag.Reverse = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();
            ViewBag.Cooper = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.Joshua = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.NotJoshua = _context.Players
                .Where(p => p.LastName == ("Cooper") && p.FirstName != ("Joshua"))
                .ToList();
            ViewBag.WyattOrAlexander = _context.Players
                .Where(p => p.FirstName == ("Alexander") || p.FirstName == ("Wyatt"))
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.AtlanticTeams = _context.Teams
            .Include(team => team.CurrLeague)
            .Where(team=> team.CurrLeague.Name == "Atlantic Soccer Conference")
            .ToList();
            ViewBag.Penguins = _context.Players
            .Include(team => team.CurrentTeam)
            .Where(player=> player.CurrentTeam.TeamName == "Penguins")
            .ToList();
            ViewBag.Collegiate = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player=> player.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
            .ToList();
            ViewBag.Lopez = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player=> player.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football") 
            .Where(player=>player.LastName == "Lopez")
            .ToList();
            ViewBag.Football = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player=> player.CurrentTeam.CurrLeague.Sport == "Football") 
            .ToList();
            ViewBag.Sophia = _context.Players
            .Include(player => player.CurrentTeam)
            .Where(player=> player.FirstName == "Sophia") 
            .ToList();
            ViewBag.SophiaLeagues = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player=> player.FirstName == "Sophia") 
            .ToList();
            ViewBag.NoRoughRiders = _context.Players
            .Include(player => player.CurrentTeam)
            .ThenInclude(team => team.CurrLeague)
            .Where(player=> player.LastName == "Flores" && player.CurrentTeam.TeamName != ("RoughRiders")) 
            .ToList();
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}