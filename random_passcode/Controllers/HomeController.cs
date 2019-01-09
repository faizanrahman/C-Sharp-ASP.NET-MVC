using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            // if(String.IsNullOrEmpty(HttpContext.Session.GetString("redirect")))
            // {
            //     return RedirectToAction("Index");
            // }
            
            int? counter = HttpContext.Session.GetInt32("counter");
            if(counter == null)
            {
                HttpContext.Session.SetInt32("counter", 0);
            } 
            else
            {
                counter = counter + 1;
                HttpContext.Session.SetInt32("counter",(int)counter);
            }
            // HttpContext.Session.SetInt32("Counter", 0);
            // HttpContext.Session.SetInt32("Counter", (int)counter);
          //ViewBag.Count = HttpContext.Session.GetInt32("Counter");
            System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        //System.Console.WriteLine(ViewBag.Count);        
            
            //Trying with demo from class
            // The demo creates a helper function generate, and calls that
            // function each time Index View is rendered.
            // Random random = new Random();
            // string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            // string passcode ="";
            // for(int i = 0; i < 14; i++)
            // {
            //     int rndIdx = random.Next(chars.Length);
            //     passcode+=chars[rndIdx];
            // }
            
            
            
            
            
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var randomString = new char[14];
            for (int i = 0; i < randomString.Length; i++)
            {
                randomString[i] = characters[random.Next(characters.Length)];
            }
            System.Console.WriteLine(randomString);
            ViewBag.random = new String(randomString);
            ViewBag.count = HttpContext.Session.GetInt32("counter");

            
            
            return View();
        }

        [HttpGet("random_word")]
        public IActionResult Generate()
        {
            // HttpContext.Session.SetString("redirect","true");
            return RedirectToAction("Index");
        }

        [HttpGet("random_word/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
