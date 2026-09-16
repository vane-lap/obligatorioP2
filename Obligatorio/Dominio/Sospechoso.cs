using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sospechoso : IValidable
    {
        #region ATRIBUTOS
        private string _nombre;
        private string _cedula;
        private DateTime _fechaNac;
        private bool _antecedentes;
        #endregion
        public Sospechoso(string nombre, string cedula, DateTime fechaNac, bool antecedentes)
        {
            _nombre = nombre;
            _cedula = cedula;
            _fechaNac = fechaNac;
            _antecedentes = antecedentes;
        }
        
        public void Validar()
        {
            if (!string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío");
            if (!string.IsNullOrEmpty(_cedula)) throw new Exception("La cédula no puede ser vacía"); // sistema va a tener que tener una lista de sospechosos para validar si hay otro sospechoso con misma cedula
            if (_fechaNac == DateTime.MinValue) throw new Exception("La fecha de nacimiento no puede ser vacía");
        }

        public override string ToString()
        {
            return ("");
        }

    }
}
