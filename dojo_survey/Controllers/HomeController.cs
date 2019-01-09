using System;
using Microsoft.AspNetCore.Mvc;
namespace dojo_survey
{
    public class HomeController : Controller
    { 
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("result")]
        public IActionResult Result(string name, string email, string location, string language, string comments)
        {
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comments = comments;
            
            return View("Result");
        }
    }
}