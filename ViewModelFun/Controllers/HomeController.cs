using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string[] names = new string[]
            {
                "Binh", "Faizan", "Jason", "Mike", "Jonny", "Meda", "Felix", "Nick"
            };
            return View(names);
        }

        // GET: /numbers
        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[] {1,2,3,4,5,6,7,8,9,10};
            return View(numbers);
        }
        
        [HttpGet("user")]
        public IActionResult User()
        {
            return View(user);
        }
        
        
        
        
        
        
        [HttpGet("users")]
        public IActionResult Users()
        {
            return View(users);
        }
    }
}
