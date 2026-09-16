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

        public void AltaEvidenciaFisica()
        {

        }

        public void AltaEvidenciaGrabacion()
        {

        }

        public void AltaEvidenciaTestimonio()
        {

        }


        public void PregargarInvestigador()
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
