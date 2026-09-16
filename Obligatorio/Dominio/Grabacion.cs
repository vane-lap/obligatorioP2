using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Grabacion : Evidencia
    {
        #region ATRIBUTOS
        private int _calidad;
        private bool _infraganti;
        #endregion
        public Grabacion(DateTime fecha, string descripcion, int calidad, bool infraganti) : base(fecha, descripcion)
        {
            _calidad = calidad;
            _infraganti = infraganti;
        }


        public override void Validar()
        {
            base.Validar();
            if (_calidad <= 0 && _calidad > 5) throw new Exception("Debe de ser un número del 1 al 5");
            
        }
        public override int CalcularPeso()
        {
            throw new NotImplementedException();
        }
    }
}
