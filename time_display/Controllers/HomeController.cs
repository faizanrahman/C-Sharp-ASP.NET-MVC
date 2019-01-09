using Microsoft.AspNetCore.Mvc;
using System;
namespace time_display.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}