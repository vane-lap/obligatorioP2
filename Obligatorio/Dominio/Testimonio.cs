using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Testimonio : Evidencia
    {
        #region ATRIBUTOS
        private string _nombre;
        private Credibilidad _credibilidad;
        #endregion

        public Testimonio(DateTime fecha, string descripcion, string nombre, Credibilidad credibilidad) : base(fecha, descripcion)
        {
            _nombre = nombre;
            _credibilidad = credibilidad;
        }

        public string Nombre { get { return _nombre; } }
        public Credibilidad Credibilidad { get { return _credibilidad; } }

        public override void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío");
            if (!Enum.IsDefined(typeof(Credibilidad), _credibilidad)) throw new Exception("No existe credibilidad de ese tipo");
        }
        
        public override string ToString()
        {
            return base.ToString() + $", de tipo Testimonio de {_nombre} y una credibilidad {_credibilidad}";
        }
        
        public override int CalcularPeso()
        {
            int pesoRetorno = base.CalcularPeso();
            if (_credibilidad.Equals(Credibilidad.ALTO) || _credibilidad.Equals(Credibilidad.MEDIO))
            {
                pesoRetorno += 10;
            }
            return pesoRetorno;
        }
    }

}
