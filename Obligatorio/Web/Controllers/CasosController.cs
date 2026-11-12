using Dominio;
using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CasosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            if (HttpContext.Session.GetString("rol") == Rol.DETECTIVE.ToString())
            {
                ViewBag.Listado = miSistema.CasosPorInvestigador(HttpContext.Session.GetString("email"));
            }
            else
            {
                ViewBag.Listado = miSistema.Casos;
            }
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

        [HttpGet]
        public IActionResult AltaCaso()
        {
            if (HttpContext.Session.GetString("rol") == null) return View("NoAuth");
            if (HttpContext.Session.GetString("rol") == Rol.FISCAL.ToString())
            {
                ViewBag.Sospechosos = miSistema.Sospechosos;
                ViewBag.Detectives = miSistema.ObtenerDetectives();
                return View();
            }
            else
            {
                return View("NoAuth");
            }
        }

        [HttpPost]
        public IActionResult AltaCaso(string nombre, string descripcion, bool cerrado, string cedulaSospechoso, string emailInvestigador)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "FISCAL") return View("NoAuth");

            ViewBag.Sospechosos = miSistema.Sospechosos;
            ViewBag.Detectives = miSistema.ObtenerDetectives();

            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre es requerido");
                if (string.IsNullOrEmpty(descripcion)) throw new Exception("La descripcion es requerida");
                if (string.IsNullOrEmpty(cedulaSospechoso)) throw new Exception("La cedula del sospechoso es requerida");
                if (string.IsNullOrEmpty(emailInvestigador)) throw new Exception("El email del investigador es requerido");

                miSistema.AltaCaso(nombre, descripcion, cerrado, cedulaSospechoso, emailInvestigador);
                ViewBag.Exito = $"El caso {nombre} fue creado con exito";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }


    }
}
