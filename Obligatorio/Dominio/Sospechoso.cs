using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sospechoso : IValidable
        #region ATRIBUTOS
        private string _nombre;
        private string _cedula;
        private DateTime _fechaNac;
        private bool _antecedentes;
        #endregion

        #region METODOS

        #endregion

        #region CONSTRUCTOR

        public void Sospechoso(string nombre, string cedula, DateTime fechaNac, bool antecedentes)
        {
            _nombre = nombre;
            _cedula = cedula;
            _fechaNac = fechaNac;
            _antecedentes = antecedentes;
        }
        #endregion
    }
}
