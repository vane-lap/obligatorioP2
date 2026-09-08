using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Caso : IValidable
    {
        #region ATRIBUTOS
        private int _id;
        private string _nombre;
        private string _descripcion;
        private bool _cerrado;
        private Sospechoso _sospechoso;
        private Investigador _investigador;
        private List<Evidencia> _evidencia = new List<Evidencia>();
        #endregion

        #region METODOS

        #endregion

        #region CONSTRUCTOR

        public void Caso(string nombre, string desc, bool cerrado, string cedula, string email)
        {
            _nombre = nombre;
            _descripcion = desc;
            _cerrado = cerrado;
        }
        #endregion
    }
}
