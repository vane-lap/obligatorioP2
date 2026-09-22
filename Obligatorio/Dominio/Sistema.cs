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

        public List<Sospechoso> Sospechosos { get => _sospechosos; }

        public Sistema()
        {
            PrecargaSospechosos();
        }

        public Sospechoso BuscarSospechosoPorCedula(string cedula)
        {
            foreach (Sospechoso unS in Sospechosos)
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

        public void AltaSospechoso(string nombre, string cedula, DateTime fechaNac, bool antecedentes)
        {
            Sospechoso s = new Sospechoso(nombre, cedula, fechaNac, antecedentes);
            s.Validar();
            if (_sospechosos.Contains(s)) throw new Exception("Ya existe un sospechoso con esos datos");
            _sospechosos.Add(s);
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

        public void PrecargaSospechosos()
        {
            AltaSospechoso("Juan Pérez", "12345678", new DateTime(1990, 5, 12), true);
            AltaSospechoso("Maria Rodríguez", "23456789", new DateTime(1985, 8, 23), false);
            AltaSospechoso("Carlos Gómez", "34567890", new DateTime(1992, 11, 4), true);
            AltaSospechoso("Ana Martínez", "45678901", new DateTime(1998, 3, 15), false);
            AltaSospechoso("Luis Silva", "56789012", new DateTime(1975, 12, 30), true);
            AltaSospechoso("Laura Fernández", "67890123", new DateTime(2000, 1, 10), false);
            AltaSospechoso("Diego López", "78901234", new DateTime(1988, 7, 19), true);
            AltaSospechoso("Sofia Díaz", "89012345", new DateTime(1995, 9, 5), false);
            AltaSospechoso("Gonzalo Romero", "11223344", new DateTime(1982, 4, 18), true);
            AltaSospechoso("Valentina Torres", "22334455", new DateTime(2001, 6, 25), false);
            AltaSospechoso("Martin Morales", "33445566", new DateTime(1993, 2, 14), true);
            AltaSospechoso("Camila Castro", "44556677", new DateTime(1997, 10, 8), false);
            AltaSospechoso("Nicolas Alvarez", "55667788", new DateTime(1989, 12, 1), true);
            AltaSospechoso("Lucia Suarez", "66778899", new DateTime(1994, 3, 22), false);
            AltaSospechoso("Joaquin Benitez", "77889900", new DateTime(1980, 5, 30), true);
        }

    }
}
