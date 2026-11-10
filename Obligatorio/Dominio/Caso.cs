using Dominio.Enums;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dominio
{
    public class Caso : IValidable
    {
        #region ATRIBUTOS
        private int _id;
        private static int _ultId = 1;
        private string _nombre;
        private string _descripcion;
        private bool _cerrado;
        private Sospechoso _sospechoso;
        private Investigador _investigador;
        private List<Evidencia> _evidencias;
        #endregion

		public int Id
		{
			get { return _id; }
		}

		public string Nombre
		{
			get { return _nombre; }
		}

        public string Descripcion
        {
            get { return _descripcion; }
        }

        public bool Cerrado
        {
            get { return _cerrado; }
        }

        public List<Evidencia> Evidencias
        {
            get { return _evidencias; }
        }

        public Investigador Investigador
        {
            get { return _investigador; }
        }

        public Sospechoso Sospechoso
        {
            get { return _sospechoso; }
        }

        public Caso(string nombre, string descripcion, bool cerrado, Sospechoso sospechoso, Investigador investigador)
        {
            _id = _ultId++;
            _nombre = nombre;
            _descripcion = descripcion;
            _cerrado = cerrado;
            _sospechoso = sospechoso;
            _investigador = investigador;
            _evidencias = new List<Evidencia>();
        }
       
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío");
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripción no puede ser vacía");
            if (_sospechoso == null) throw new Exception("El caso debe de tener un sospechoso");
            if (_investigador == null) throw new Exception("El caso debe de tener un investigador");
            if (!_investigador.Rol.Equals(Rol.DETECTIVE)) throw new Exception("El caso debe de tener un investigador de tipo detective asignado");
        }

        public override string ToString() 
        {
            string stringRetorno = ($"Id: {_id} - Nombre: {_nombre} - Evidencias: \n");

            foreach (Evidencia unE in _evidencias)
            {
                stringRetorno += unE.ToString() + "\n";
            }
            return stringRetorno;
        }

		public override bool Equals(object? obj)
        {
            return obj is Caso unC && _nombre.ToUpper() == unC._nombre.ToUpper();
        }

        public string RecomendarImputacion()
        {
            int pesoTotal = 0;
            foreach (Evidencia e in _evidencias)
            {
                pesoTotal += e.CalcularPeso();
            }
            if (_sospechoso.TieneAntecedente)
            {
                pesoTotal += 10;
            }
            if (pesoTotal < 30)
            {
                return $"DESESTIMADO: El caso {_nombre} carece de fundamentos. El peso de la prueba es {pesoTotal} y debería ser desestimado finalizando la investigación en contra de {_sospechoso.Nombre}";
            } else if (pesoTotal < 70)
            {
                return $"CONTINUAR INVESTIGANDO: El caso {_nombre} parece ir por el camino correcto, pero necesita más investigación. El peso de la prueba es {pesoTotal} pero aún no hay información suficiente para imputar a {_sospechoso.Nombre}";
            }else
            {
                if (pesoTotal > 100)
                {
                    pesoTotal = 100;
                }
                return $"IMPUTACIÓN INMINENTE: El caso {_nombre} está resuelto. El peso de la prueba es {pesoTotal} y debería imputarse a {_sospechoso.Nombre} inmediatamente";
            }
        }

        public int CalcularPesoDeEvidencias()
        {
            int pesoTotal = 0;
            foreach (Evidencia e in _evidencias)
            {
                pesoTotal += e.CalcularPeso();
            }
            if (_sospechoso.TieneAntecedente)
            {
                pesoTotal += 10;
            }
            if (pesoTotal > 100)
            {
                pesoTotal = 100;
            }
            return pesoTotal;
        }


        public List<Fisica> ObtenerEvidenciasFisicas()
        {
            List<Fisica> listaRetorno = new List<Fisica>();
            foreach (Evidencia unE in _evidencias)
            {
                if (unE is Fisica fisica)
                {
                    listaRetorno.Add(fisica);
                }
            }
            return listaRetorno;
        }
        public List<Grabacion> ObtenerEvidenciasGrabaciones()
        {
            List<Grabacion> listaRetorno = new List<Grabacion>();
            foreach (Evidencia unE in _evidencias)
            {
                if (unE is Grabacion grabacion)
                {
                    listaRetorno.Add(grabacion);
                }
            }
            return listaRetorno;
        }
        public List<Testimonio> ObtenerEvidenciasTestimonios()
        {
            List<Testimonio> listaRetorno = new List<Testimonio>();
            foreach (Evidencia unE in _evidencias)
            {
                if (unE is Testimonio testimonio)
                {
                    listaRetorno.Add(testimonio);
                }
            }
            return listaRetorno;
        }


    }
}
