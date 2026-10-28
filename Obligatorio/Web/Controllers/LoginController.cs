using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string contrasena)
        {
            return View();
        }
    }
}
