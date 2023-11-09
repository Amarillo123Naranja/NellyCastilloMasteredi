using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
