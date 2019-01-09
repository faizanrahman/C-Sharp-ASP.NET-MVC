using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Factories;
using DojoLeague.Models;

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly DojoFactory dojosFactory;
        private readonly NinjaFactory ninjaFactory;
        public HomeController()
        {
            dojosFactory = new DojoFactory();
            ninjaFactory = new NinjaFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Ninjas = ninjaFactory.GetAll();
            System.Console.WriteLine(ViewBag.Ninjas);
            ViewBag.Dojos = dojosFactory.GetAll();

            IEnumerable<ninjas> ninjas = ninjaFactory.GetAll();

            foreach (var ninja in ninjas)
            {
                // System.Console.WriteLine(ninja.dojo.name);
            }

            return View();
        }
        [HttpGet("dojos/{id}")]
        public IActionResult IndividualDojo(int id)
        {
            ViewBag.Dojo = dojosFactory.FindById(id);
            return View("IndividualDojo");
        }

        [HttpGet("dojos")]
        public IActionResult Dojos()
        {
            ViewBag.Dojos = dojosFactory.GetAll();
            return View("Dojos");
        }

        [HttpPost("createNinja")]
        public IActionResult Create(ninjas ninja)
        {
            ninjaFactory.CreateNinja(ninja);
            return RedirectToAction("Index");
        }

        [HttpPost("createDojo")]
        public IActionResult CreateDojo(dojos dojo)
        {
            dojosFactory.CreateDojo(dojo);
            return RedirectToAction("Index");
        } 
    }
}
