using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CasosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            ViewBag.Listado = miSistema.Casos;
            return View();
        }

        [HttpGet]
        public IActionResult Detalles(int id)
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            ViewBag.Caso = miSistema.CasoPorId(id);
            return View();
        }
    }
}
