using System;
using System.Collections.Generic;
using DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;  // Name of the project.Models

namespace quoting_dojo.Controllers {
    public class HomeController : Controller {
        // GET: /Home/
        [HttpGet]
        [Route ("")]
        public IActionResult Index () {
            return View ();
        }

        //Add a Quote to the database
        [HttpPost]
        [Route ("quotes")]
        public IActionResult AddQuote (Quote quote) {   // Type of param we are passing, 2nd one we can call banana.
            if (ModelState.IsValid) {
                string query = $"INSERT INTO quote (Name, Description) VALUES ('{quote.Name}', '{quote.Description}')";
                DbConnector.Execute (query);
                return RedirectToAction ("Index");
            }
            return View ("Index");
        }

        //Get all Quotes
        [HttpGet]
        [Route ("quotes")]
        public IActionResult GetAll (Quote quote) {
            // List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quote");
            List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quote ORDER BY id DESC");
            System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");
            System.Console.WriteLine(AllQuotes[0]["Name"]);
            return View ("quotes", AllQuotes);
        }

    }
}