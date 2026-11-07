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
        public IActionResult Index(string email, string pass)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") != null) return View("NoAuth");
                if (string.IsNullOrEmpty(email)) throw new Exception("Debe ingresar email");
                if (string.IsNullOrEmpty(pass)) throw new Exception("Debe ingresar una contraseña");
                Investigador investigador = miSistema.Login(email, pass);
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", investigador.Rol.ToString());
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            ViewBag.Investigador = miSistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));
            return View();
        }
    }
}
