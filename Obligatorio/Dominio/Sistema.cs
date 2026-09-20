using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        private List<Investigador> _investigadores = new List<Investigador>();
        private List<Caso> _casos = new List<Caso>();
        private List<Sospechoso> _sospechosos = new List<Sospechoso>();


        public Sistema()
        {

        }

        public Sospechoso BuscarSospechosoPorCedula(string cedula)
        {
            foreach (Sospechoso unS in _sospechosos)
            {
                if (unS.Cedula == cedula) return unS;
            }
            return null;
        }

        public Investigador BuscarInvestigadorPorMail(string email)
        {
            foreach (Investigador unI in _investigadores)
            {
                if (unI.Email == email) return unI;
            }
            return null;
        }


        public void AltaInvestigador()
        {

        }

        public void AltaCaso()
        {

        }

        public void AltaSospechoso()
        {

        }
        
        public void AltaEvidenciaFisica(DateTime fecha, string descripcion, bool tieneHuellas, Caso caso)
        {
            Fisica f = new Fisica(fecha, descripcion, tieneHuellas);
            f.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso._evidencias.Contains(f)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso._evidencias.Add(f);
        }

        public void AltaEvidenciaGrabacion(DateTime fecha, string descripcion, int calidad, bool infraganti, Caso caso)
        {
            Grabacion g = new Grabacion(fecha, descripcion, calidad, infraganti);
            g.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso._evidencias.Contains(g)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso._evidencias.Add(g);
        }

        public void AltaEvidenciaTestimonio(DateTime fecha, string descripcion, string nombre, Credibilidad credibilidad, Caso caso)
        {
            Testimonio t = new Testimonio(fecha, descripcion, nombre, credibilidad);
            t.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso._evidencias.Contains(t)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso._evidencias.Add(t);
        }


        public void PrecargarInvestigador()
        {

        }

        public void PrecargarCasos()
        {

        }

        public void PrecargarSospechosos()
        {

        }

    }
}
