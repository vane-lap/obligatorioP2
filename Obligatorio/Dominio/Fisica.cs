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

        public override void Validar()
        {
            base.Validar();
        }

        public override string ToString()
        {
            string retorno = base.ToString() + ", de tipo Fisica";
            if (_tieneHuellas)
                retorno += " y con huellas";
            else
            {
                retorno += " y sin huellas";
            }
            return retorno;
        }

        public override int CalcularPeso()
        {
            throw new NotImplementedException();
        }
    }
}
