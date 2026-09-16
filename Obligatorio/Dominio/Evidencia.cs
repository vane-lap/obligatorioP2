using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Interfaces;

namespace Dominio
{
    public abstract class Evidencia : IValidable
    {
        #region ATRIBUTOS
        private int _id;
        private DateTime _fecha;
        private string _descripcion;
        private static int _ultId = 1;
        #endregion

        public Evidencia(DateTime fecha, string descripcion)
        {
            _id = _ultId++;
            _fecha = fecha;
            _descripcion = descripcion;
        }

        public virtual void Validar()
        {
            if ( _fecha == DateTime.MinValue && _fecha > DateTime.Today) throw new Exception("La fecha no puede ser vacía ni mayor al día de hoy");
            if (!string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripción no puede ser vacía");
        }

        public abstract int CalcularPeso();



    }
}
