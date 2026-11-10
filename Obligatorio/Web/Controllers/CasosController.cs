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
            Caso caso = miSistema.CasoPorId(id);
            ViewBag.Fisicas = caso.ObtenerEvidenciasFisicas();
            ViewBag.Grabaciones = caso.ObtenerEvidenciasGrabaciones();
            ViewBag.Testimonios = caso.ObtenerEvidenciasTestimonios();
            ViewBag.Caso = caso;
            return View();
        }
    }
}
