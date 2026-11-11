using Dominio;
using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class InvestigadoresController : Controller
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

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string nombre, string email, string contrasena)
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
