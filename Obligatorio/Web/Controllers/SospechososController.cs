using Dominio;
using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SospechososController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        public IActionResult Index(int? edad)
        {
            if ((HttpContext.Session.GetString("rol") == null) || (HttpContext.Session.GetString("rol") != Rol.DETECTIVE.ToString())) return View("NoAuth");
            if (edad == null)
            {
                ViewBag.Listado = miSistema.Sospechosos;
            }
            else
            {
                ViewBag.Listado = miSistema.ObtenerSospechososPorEdad((int)edad);
            }
            return View();
        }
    }
}
