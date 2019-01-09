using Microsoft.AspNetCore.Mvc;
namespace portfolio_assignment.Controllers
{
    public class HomeController : Controller
    {
        //localhost:5000
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        //localhost:5000/projects
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View("Projects");
        }

        //localhost:5000/contact
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View("Contact");
        }

    }
}