using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        private List<Investigador> _investigadores = new List<Investigador>();
        private List<Caso> _casos = new List<Caso>();
        private List<Sospechoso> _sospechosos = new List<Sospechoso>();

        public List<Sospechoso> Sospechosos
        {
            get { return _sospechosos; }
        }

        public List<Caso> Casos
        {
            get { return _casos; }
        }

        public Sistema()
        {
            PrecargaSospechosos();
            PrecargarInvestigadores();
            PrecargarCasos();
            PrecargarEvidencias();
        }

        public Sospechoso BuscarSospechosoPorCedula(string cedula)
        {
			if (cedula == null) throw new Exeption("La cedula no puede ser vacia");
			foreach (Sospechoso unS in _sospechosos)
			{
				if (unS.Cedula == cedula) return unS;
			}
			throw new Exception("El Sospechoso no existe en el Sistema");
			return null;
			/*
            Sospechoso sospechoso = null;
            foreach (Sospechoso unS in Sospechosos)
            {
                if (unS.Cedula == cedula) 
                {
                    sospechoso = unS;
                }
            }
            if (sospechoso == null)
            {
                throw new Exception("El Sospechoso no existe en el Sistema");
            }
            return sospechoso;
			*/
        }

        public Investigador BuscarInvestigadorPorMail(string email)
        {
			if (email == null) throw new Exception("El email no puede ser vacio");
			foreach (Investigador unI in _investigadores)
			{
				if (unI.Email == email) return unI;
			}
			throw new Exception("El investigador no existe en el Sistema");
			return null;
			/*
            Investigador investigador = null;
            foreach (Investigador unI in _investigadores)
            {
                if (unI.Email == email)
                {
                    investigador = unI;
                }
            }
            if(investigador == null)
            {
                throw new Exception("El investigador no existe en el Sistema");
            }
            return investigador;
			*/
        }

        public void AltaInvestigador(string email, string contrasena, string nombre, Rol rol)
        {
			Investigador i = new Investigador(email, contrasena, nombre, rol);
			i.Validar();
			if (_investigadores.Contains(i)) throw new Exception("Ya existe un investigador con esos datos");
			_investigadores.Add(i);
        }

        public void AltaCaso(string nombre, string descripcion, bool cerrado, string cedulaSospechoso, string emailInvestigador)
        {
            Sospechoso sospechoso = BuscarSospechosoPorCedula(cedulaSospechoso);
            Investigador investigador = BuscarInvestigadorPorMail(emailInvestigador);

            Caso c = new Caso(nombre, descripcion, cerrado, sospechoso, investigador);
            c.Validar();
            if (_casos.Contains(c)) throw new Exception("Ya existe un caso con ese nombre");
            _casos.Add(c);
        }

        public void AltaSospechoso(string nombre, string cedula, DateTime fechaNac, bool antecedentes)
        {
            Sospechoso s = new Sospechoso(nombre, cedula, fechaNac, antecedentes);
            s.Validar();
            if (_sospechosos.Contains(s)) throw new Exception("Ya existe un sospechoso con esos datos");
            _sospechosos.Add(s);
        }
        
        public void AltaEvidenciaFisica(DateTime fecha, string descripcion, bool tieneHuellas, Caso caso)
        {
            Fisica f = new Fisica(fecha, descripcion, tieneHuellas);
            f.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso.Evidencias.Contains(f)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso.Evidencias.Add(f);
        }

        public void AltaEvidenciaGrabacion(DateTime fecha, string descripcion, int calidad, bool infraganti, Caso caso)
        {
            Grabacion g = new Grabacion(fecha, descripcion, calidad, infraganti);
            g.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso.Evidencias.Contains(g)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso.Evidencias.Add(g);
        }

        public void AltaEvidenciaTestimonio(DateTime fecha, string descripcion, string nombre, Credibilidad credibilidad, Caso caso)
        {
            Testimonio t = new Testimonio(fecha, descripcion, nombre, credibilidad);
            t.Validar();
            if (!_casos.Contains(caso))
                throw new Exception("El caso donde quieres ingresar esta evidencia no es valido, no se encuentra dentro de nuestro sistema");
            if (caso.Evidencias.Contains(t)) throw new Exception("Ya existe esta evidencia dentro de este caso");
            caso.Evidencias.Add(t);
        }


        public void PrecargarInvestigadores()
        {
            AltaInvestigador("fiscal1@investigacion.gob", "Pass1234!", "Carlos Gómez", Rol.FISCAL);
            AltaInvestigador("fiscal2@investigacion.gob", "Pass1234!", "María Rodríguez", Rol.FISCAL);
            AltaInvestigador("fiscal3@investigacion.gob", "Pass1234!", "Juan Martínez", Rol.FISCAL);
            AltaInvestigador("fiscal4@investigacion.gob", "Pass1234!", "Laura Fernández", Rol.FISCAL);
            AltaInvestigador("fiscal5@investigacion.gob", "Pass1234!", "Roberto Sánchez", Rol.FISCAL);

            AltaInvestigador("detective1@investigacion.gob", "Pass1234!", "Ana López", Rol.DETECTIVE);
            AltaInvestigador("detective2@investigacion.gob", "Pass1234!", "Diego Pérez", Rol.DETECTIVE);
            AltaInvestigador("detective3@investigacion.gob", "Pass1234!", "Sofia Morales", Rol.DETECTIVE);
            AltaInvestigador("detective4@investigacion.gob", "Pass1234!", "Gabriel Romero", Rol.DETECTIVE);
            AltaInvestigador("detective5@investigacion.gob", "Pass1234!", "Lucía Torres", Rol.DETECTIVE);
        }

        public void PrecargaSospechosos()
        {
            AltaSospechoso("Juan Pérez", "12345678", new DateTime(1990, 5, 12), true);
            AltaSospechoso("Maria Rodríguez", "23456789", new DateTime(1985, 8, 23), false);
            AltaSospechoso("Carlos Gómez", "34567890", new DateTime(1992, 11, 4), true);
            AltaSospechoso("Ana Martínez", "45678901", new DateTime(1998, 3, 15), false);
            AltaSospechoso("Luis Silva", "56789012", new DateTime(1975, 12, 30), true);
            AltaSospechoso("Laura Fernández", "67890123", new DateTime(2000, 1, 10), false);
            AltaSospechoso("Diego López", "78901234", new DateTime(1988, 7, 19), true);
            AltaSospechoso("Sofia Díaz", "89012345", new DateTime(1995, 9, 5), false);
            AltaSospechoso("Gonzalo Romero", "11223344", new DateTime(1982, 4, 18), true);
            AltaSospechoso("Valentina Torres", "22334455", new DateTime(2001, 6, 25), false);
            AltaSospechoso("Martin Morales", "33445566", new DateTime(1993, 2, 14), true);
            AltaSospechoso("Camila Castro", "44556677", new DateTime(1997, 10, 8), false);
            AltaSospechoso("Nicolas Alvarez", "55667788", new DateTime(1989, 12, 1), true);
            AltaSospechoso("Lucia Suarez", "66778899", new DateTime(1994, 3, 22), false);
            AltaSospechoso("Joaquin Benitez", "77889900", new DateTime(1980, 5, 30), true);
        }

        public void PrecargarCasos()
        {
            AltaCaso("Robo en Joyería Central", "Sustracción de joyas de alta gama.", false, "12345678", "detective1@investigacion.gob");
            AltaCaso("Fraude Bancario Norte", "Desvío ilegal de fondos corporativos.", false, "23456789", "detective2@investigacion.gob");
            AltaCaso("Hurto en Museo Nacional", "Sustracción de pintura histórica.", true, "34567890", "detective3@investigacion.gob");
            AltaCaso("Ciberataque Financiero", "Acceso no autorizado a servidores.", false, "45678901", "detective4@investigacion.gob");
            AltaCaso("Contrabando Marina", "Carga no declarada en puerto comercial.", true, "56789012", "detective5@investigacion.gob");
            AltaCaso("Estafa Inmobiliaria", "Venta fraudulenta de propiedades ficticias.", false, "67890123", "detective1@investigacion.gob");
            AltaCaso("Falsificación de Documentos", "Emisión de pasaportes apócrifos.", true, "78901234", "detective2@investigacion.gob");
            AltaCaso("Extorsión Comercial", "Amenazas a comercios del centro.", false, "89012345", "detective3@investigacion.gob");
            AltaCaso("Robo de Vehículo de Carga", "Sustracción de camión con mercadería.", false, "11223344", "detective4@investigacion.gob");
            AltaCaso("Sabotaje Industrial", "Daños intencionados en maquinaria de fábrica.", true, "22334455", "detective5@investigacion.gob");
        }


        public void PrecargarEvidencias()
        {
            AltaEvidenciaFisica(new DateTime(2024, 1, 15), "Huella dactilar en la vitrina principal", true, _casos[0]);
            AltaEvidenciaGrabacion(new DateTime(2024, 1, 15), "Video de cámara de seguridad de la entrada", 4, true, _casos[0]);
            AltaEvidenciaTestimonio(new DateTime(2024, 1, 16), "Declaración del guardia de turno", "Carlos Pérez", Credibilidad.ALTO, _casos[0]);
            AltaEvidenciaFisica(new DateTime(2024, 1, 16), "Herramienta de corte olvidada en la escena", false, _casos[0]);

            AltaEvidenciaGrabacion(new DateTime(2024, 2, 10), "Registro de audio de llamada extorsiva", 3, false, _casos[1]);
            AltaEvidenciaTestimonio(new DateTime(2024, 2, 11), "Testimonio del contador de la empresa", "María Gómez", Credibilidad.NORMAL, _casos[1]);
            AltaEvidenciaFisica(new DateTime(2024, 2, 12), "Dispositivo USB hallado en la oficina", true, _casos[1]);
            AltaEvidenciaTestimonio(new DateTime(2024, 2, 12), "Declaración del analista de sistemas", "Juan Rodríguez", Credibilidad.ALTO, _casos[1]);

            AltaEvidenciaFisica(new DateTime(2024, 3, 5), "Marco de la pintura dañado y abandonado", true, _casos[2]);
            AltaEvidenciaGrabacion(new DateTime(2024, 3, 5), "Grabación del pasillo lateral del museo", 5, true, _casos[2]);
            AltaEvidenciaTestimonio(new DateTime(2024, 3, 6), "Testimonio del guía del turno noche", "Roberto Martínez", Credibilidad.BAJO, _casos[2]);
            AltaEvidenciaGrabacion(new DateTime(2024, 3, 6), "Audio de la alarma de seguridad", 2, false, _casos[2]);

            AltaEvidenciaFisica(new DateTime(2024, 4, 1), "Disco duro extraído del servidor afectado", false, _casos[3]);
            AltaEvidenciaTestimonio(new DateTime(2024, 4, 2), "Declaración del administrador de red", "Ana López", Credibilidad.ALTO, _casos[3]);
            AltaEvidenciaGrabacion(new DateTime(2024, 4, 2), "Video del centro de cómputos", 3, false, _casos[3]);
            AltaEvidenciaTestimonio(new DateTime(2024, 4, 3), "Testimonio de empleado del área IT", "Diego Sánchez", Credibilidad.NORMAL, _casos[3]);

            AltaEvidenciaFisica(new DateTime(2024, 5, 20), "Muestra de mercadería ilegal incautada", false, _casos[4]);
            AltaEvidenciaGrabacion(new DateTime(2024, 5, 20), "Grabación con dron del buque en puerto", 4, true, _casos[4]);
            AltaEvidenciaTestimonio(new DateTime(2024, 5, 21), "Declaración del inspector aduanero", "Fernando Torres", Credibilidad.ALTO, _casos[4]);
            AltaEvidenciaFisica(new DateTime(2024, 5, 21), "Contenedor adulterado con restos biológicos", true, _casos[4]);

            AltaEvidenciaTestimonio(new DateTime(2024, 6, 10), "Testimonio de la víctima del fraude", "Lucía Fernández", Credibilidad.ALTO, _casos[5]);
            AltaEvidenciaFisica(new DateTime(2024, 6, 11), "Contrato falso impreso con firmas apócrifas", true, _casos[5]);
            AltaEvidenciaGrabacion(new DateTime(2024, 6, 11), "Grabación de videollamada con la inmobiliaria", 3, false, _casos[5]);
            AltaEvidenciaTestimonio(new DateTime(2024, 6, 12), "Declaración del escribano público", "Gabriel Ruiz", Credibilidad.NORMAL, _casos[5]);

            AltaEvidenciaFisica(new DateTime(2024, 7, 1), "Pasaportes falsificados incautados", true, _casos[6]);
            AltaEvidenciaTestimonio(new DateTime(2024, 7, 2), "Testimonio del oficial de fronteras", "Patricia Díaz", Credibilidad.ALTO, _casos[6]);
            AltaEvidenciaGrabacion(new DateTime(2024, 7, 2), "Video de cámara de la oficina de migración", 5, true, _casos[6]);
            AltaEvidenciaFisica(new DateTime(2024, 7, 3), "Sello oficial clonado hallado en el lugar", true, _casos[6]);

            AltaEvidenciaGrabacion(new DateTime(2024, 8, 15), "Audio de mensaje de voz con amenazas", 2, false, _casos[7]);
            AltaEvidenciaTestimonio(new DateTime(2024, 8, 16), "Declaración del dueño del local extorsionado", "Gonzalo Silva", Credibilidad.ALTO, _casos[7]);
            AltaEvidenciaFisica(new DateTime(2024, 8, 16), "Nota imprescripta manuscrita de la amenaza", true, _casos[7]);
            AltaEvidenciaTestimonio(new DateTime(2024, 8, 17), "Testimonio de un cliente testigo del hecho", "Sofia Romero", Credibilidad.NORMAL, _casos[7]);

            AltaEvidenciaFisica(new DateTime(2024, 9, 8), "GPS rastreador hallado en la ruta", true, _casos[8]);
            AltaEvidenciaGrabacion(new DateTime(2024, 9, 8), "Video de cámara de seguridad de la peaje", 4, true, _casos[8]);
            AltaEvidenciaTestimonio(new DateTime(2024, 9, 9), "Declaración del chofer del camión", "Esteban Castro", Credibilidad.NORMAL, _casos[8]);
            AltaEvidenciaFisica(new DateTime(2024, 9, 9), "Llave duplicada encontrada cerca del camión", false, _casos[8]);

            AltaEvidenciaFisica(new DateTime(2024, 10, 1), "Pieza de maquinaria saboteada", true, _casos[9]);
            AltaEvidenciaGrabacion(new DateTime(2024, 10, 1), "Grabación de cámara térmica de la fábrica", 3, true, _casos[9]);
            AltaEvidenciaTestimonio(new DateTime(2024, 10, 2), "Testimonio del jefe de mantenimiento", "Hugo Morales", Credibilidad.ALTO, _casos[9]);
            AltaEvidenciaTestimonio(new DateTime(2024, 10, 2), "Declaración del supervisor de línea", "Laura Acosta", Credibilidad.BAJO, _casos[9]);
        }


        public List<Sospechoso> ObtenerSospechososConAntecedentes()
        {
            List<Sospechoso> listaRetorno = new List<Sospechoso>();
            foreach(Sospechoso unS in _sospechosos)
            {
                if(unS.TieneAntecedente)
                {
                    listaRetorno.Add(unS);
                }
            }
            return listaRetorno;
        }

        public List<Caso> CasosPorInvestigador(string email)
        {
            List<Caso> listaRetorno = new List<Caso>();
            Investigador investigador = BuscarInvestigadorPorMail(email);
            foreach (Caso unC in _casos)
            {
                if (investigador == unC.Investigador)
                {
                    listaRetorno.Add(unC);
                }
            }
            return listaRetorno;
        }

    }
}
