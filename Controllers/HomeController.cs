using Microsoft.AspNetCore.Mvc;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Welcome to Department Management");
        }
    }
}
