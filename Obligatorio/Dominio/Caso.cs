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

        public List<Evidencia> Evidencias
        {
            get { return _evidencias; }
        }

        public Investigador Investigador
        {
            get { return _investigador; }
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
            if (Evidencias == null) throw new Exception("El caso no puede tener una lista de evidencias nula");// revisar si es necesario
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

        public void RecomendarImputacion()
        {

        }

    }
}
