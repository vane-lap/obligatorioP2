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
            throw new NotImplementedException();
        }
    }

}
