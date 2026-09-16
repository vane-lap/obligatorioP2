using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fisica : Evidencia
    {
        #region ATRIBUTOS
        private bool _tieneHuellas;
        #endregion
        public Fisica(DateTime fecha, string descripcion, bool tieneHuellas) : base(fecha, descripcion)
        {
            _tieneHuellas = tieneHuellas;
        }
        public override int CalcularPeso()
        {
            throw new NotImplementedException();
        }
        public override void Validar()
        {
            base.Validar();
        }
    }
}
