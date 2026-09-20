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
        
        public override string ToString()
        {
            string retorno = base.ToString() + $", de tipo Grabacion y una calidad de {_calidad} de 5";
            if (_infraganti)
                retorno += " captado infraganti";
            else
            {
                retorno += " sin ser captado infraganti";
            }
            return retorno;
        }
        
        public override int CalcularPeso()
        {
            throw new NotImplementedException();
        }
    }
}
