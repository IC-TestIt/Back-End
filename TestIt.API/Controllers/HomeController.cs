using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestIt.API.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Test It!";
        }
    }
}
