using Dominio;
using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RegistroController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombre, string email, string contrasena)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre es requerido");
                if (string.IsNullOrEmpty(email)) throw new Exception("El email es requerido");
                if (string.IsNullOrEmpty(contrasena)) throw new Exception("La contraseña es requerida");

                miSistema.AltaInvestigador(email, contrasena, nombre, 0);
                ViewBag.Exito = $"Investigador {nombre} creado con exito";
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", Rol.DETECTIVE.ToString());
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Nombre = nombre;
                ViewBag.Email = email;
                ViewBag.Contrasena = contrasena;
            }
            return View();
        }
    }
}
