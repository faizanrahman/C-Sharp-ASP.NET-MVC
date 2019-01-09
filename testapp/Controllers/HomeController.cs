using Microsoft.AspNetCore.Mvc;
namespace testapp
{
    public class HomeController : Controller
    {
        //Requests
        //localhost:5000
        [RouteAttribute("")]
        [HttpGet]
        public string Index()
        {
            return "Hello from Controller";
        }


        //localhost:5000/hello
        [Route("hello")]
        [HttpGet]
        public string Hello()
        {
            return "Hi Again";
        }

        //localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location)
        {
            return $"Hello {username} from {location}";
        }
    }
}