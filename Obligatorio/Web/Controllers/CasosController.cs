using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CasosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
