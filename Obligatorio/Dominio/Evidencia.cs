using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Evidencia : IValidable
    {
        #region ATRIBUTOS
        private int _id;
        private DateTime _fecha;
        private string _descripcion;
        private Tipo _tipo;


        #endregion

        #region METODOS

        #endregion

        #region CONSTRUCTOR

        public void Evidencia(DateTime fecha, string descripcion, Tipo tipo)
        {
            _fecha = fecha;
            _descripcion = descripcion;
            _tipo = tipo;
        }
        #endregion
    }
}
