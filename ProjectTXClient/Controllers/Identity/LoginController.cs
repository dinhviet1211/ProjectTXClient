using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTXClient.Controllers.Identity
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
