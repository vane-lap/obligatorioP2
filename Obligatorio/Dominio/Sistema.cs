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
        }

        public Investigador BuscarInvestigadorPorMail(string email)
        {
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
            AltaInvestigador("fiscal1@email.com", "123456", "Juan Pérez", Rol.FISCAL);
            AltaInvestigador("fiscal2@email.com", "123456", "Ana García", Rol.FISCAL);
            AltaInvestigador("fiscal3@email.com", "123456", "Carlos López", Rol.FISCAL);
            AltaInvestigador("fiscal4@email.com", "123456", "María Rodríguez", Rol.FISCAL);
            AltaInvestigador("fiscal5@email.com", "123456", "Pedro Martínez", Rol.FISCAL);
            AltaInvestigador("detective1@email.com", "123456", "Luis Fernández", Rol.DETECTIVE);
            AltaInvestigador("detective2@email.com", "123456", "Sofía González", Rol.DETECTIVE);
            AltaInvestigador("detective3@email.com", "123456", "Diego Silva", Rol.DETECTIVE);
            AltaInvestigador("detective4@email.com", "123456", "Laura Pereira", Rol.DETECTIVE);
            AltaInvestigador("detective5@email.com", "123456", "Martín Castro", Rol.DETECTIVE);
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
            AltaCaso("Caso 1", "Investigación por robo", false, "12345678", "detective1@email.com");
            AltaCaso("Caso 2", "Investigación por fraude", true, "23456789", "detective2@email.com");
            AltaCaso("Caso 3", "Investigación por vandalismo", false, "34567890", "detective3@email.com");
            AltaCaso("Caso 4", "Investigación por amenazas", true, "45678901", "detective4@email.com");
            AltaCaso("Caso 5", "Investigación por estafa", false, "56789012", "detective5@email.com");
            AltaCaso("Caso 6", "Investigación por hurto", true, "67890123", "detective1@email.com");
            AltaCaso("Caso 7", "Investigación por secuestro", false, "78901234", "detective2@email.com");
            AltaCaso("Caso 8", "Investigación por extorsión", true, "89012345", "detective3@email.com");
            AltaCaso("Caso 9", "Investigación por daños", false, "11223344", "detective4@email.com");
            AltaCaso("Caso 10", "Investigación por contrabando", true, "22334455", "detective5@email.com");
            AltaCaso("Caso 11", "Investigación por allanamiento", false, "33445566", "detective1@email.com");
            AltaCaso("Caso 12", "Investigación por corrupción", true, "44556677", "detective2@email.com");
            AltaCaso("Caso 13", "Investigación por desaparición", false, "55667788", "detective3@email.com");
            AltaCaso("Caso 14", "Investigación por falsificación", true, "66778899", "detective4@email.com");
            AltaCaso("Caso 15", "Investigación por incendio", false, "77889900", "detective5@email.com");
        }


        public void PrecargarEvidencias()
        {
            AltaEvidenciaFisica(new DateTime(2026, 1, 10), "Huella encontrada en la puerta de acceso", true, _casos[0]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 11), "Grabación de cámara de seguridad del local", 4, true, _casos[0]);
            AltaEvidenciaTestimonio(new DateTime(2026, 1, 12), "Testimonio de un vecino que observó movimientos sospechosos", "Carlos Pérez", Credibilidad.ALTO, _casos[0]);
            AltaEvidenciaFisica(new DateTime(2026, 1, 13), "Herramienta encontrada cerca del lugar del robo", false, _casos[0]);

            AltaEvidenciaFisica(new DateTime(2026, 1, 14), "Documentación bancaria relacionada con movimientos sospechosos", true, _casos[1]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 15), "Grabación de una reunión entre los involucrados", 5, false, _casos[1]);
            AltaEvidenciaTestimonio(new DateTime(2026, 1, 16), "Testimonio de un empleado sobre las operaciones realizadas", "María González", Credibilidad.ALTO, _casos[1]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 17), "Registro audiovisual del ingreso a las oficinas", 3, false, _casos[1]);

            AltaEvidenciaFisica(new DateTime(2026, 1, 18), "Pintura encontrada en una pared dañada", true, _casos[2]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 19), "Grabación de cámara de seguridad de la vía pública", 4, true, _casos[2]);
            AltaEvidenciaTestimonio(new DateTime(2026, 1, 20), "Testimonio de un testigo que presenció los daños", "Luis Rodríguez", Credibilidad.NORMAL, _casos[2]);
            AltaEvidenciaFisica(new DateTime(2026, 1, 21), "Objeto utilizado para provocar los daños", false, _casos[2]);

            AltaEvidenciaFisica(new DateTime(2026, 1, 22), "Nota con amenazas encontrada en el domicilio", true, _casos[3]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 23), "Mensaje de voz con contenido amenazante", 5, true, _casos[3]);
            AltaEvidenciaTestimonio(new DateTime(2026, 1, 24), "Testimonio de la persona amenazada", "Ana Martínez", Credibilidad.ALTO, _casos[3]);
            AltaEvidenciaFisica(new DateTime(2026, 1, 25), "Teléfono utilizado para enviar mensajes", true, _casos[3]);

            AltaEvidenciaFisica(new DateTime(2026, 1, 26), "Comprobante de transferencia bancaria", false, _casos[4]);
            AltaEvidenciaGrabacion(new DateTime(2026, 1, 27), "Grabación de llamada relacionada con la estafa", 4, false, _casos[4]);
            AltaEvidenciaTestimonio(new DateTime(2026, 1, 28), "Testimonio de una persona afectada", "Jorge Fernández", Credibilidad.ALTO, _casos[4]);
            AltaEvidenciaFisica(new DateTime(2026, 1, 29), "Contrato utilizado para concretar la operación", false, _casos[4]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 1), "Objeto sustraído encontrado en poder del sospechoso", true, _casos[5]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 2), "Grabación del ingreso al establecimiento", 3, true, _casos[5]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 3), "Testimonio de un empleado del establecimiento", "Pedro Silva", Credibilidad.NORMAL, _casos[5]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 4), "Grabación del momento en que se retira el objeto", 5, true, _casos[5]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 5), "Prenda encontrada en el lugar donde estuvo retenida la víctima", true, _casos[6]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 6), "Grabación de una cámara cercana al lugar", 4, true, _casos[6]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 7), "Testimonio de un testigo que observó el traslado", "Sofía López", Credibilidad.ALTO, _casos[6]);
            AltaEvidenciaFisica(new DateTime(2026, 2, 8), "Objeto personal perteneciente a la víctima", true, _casos[6]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 9), "Documento con instrucciones para realizar el pago", true, _casos[7]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 10), "Grabación de una conversación entre los involucrados", 5, false, _casos[7]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 11), "Testimonio de la persona que recibió las amenazas", "Martín Castro", Credibilidad.ALTO, _casos[7]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 12), "Registro de una llamada relacionada con la extorsión", 4, false, _casos[7]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 13), "Fragmentos encontrados en el lugar de los daños", true, _casos[8]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 14), "Grabación de seguridad del establecimiento afectado", 4, true, _casos[8]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 15), "Testimonio del propietario del establecimiento", "Diego Acosta", Credibilidad.ALTO, _casos[8]);
            AltaEvidenciaFisica(new DateTime(2026, 2, 16), "Herramienta encontrada junto a los objetos dañados", false, _casos[8]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 17), "Mercadería sin documentación encontrada durante la inspección", true, _casos[9]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 18), "Grabación del ingreso de la mercadería", 5, true, _casos[9]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 19), "Testimonio de un empleado del depósito", "Laura Romero", Credibilidad.NORMAL, _casos[9]);
            AltaEvidenciaFisica(new DateTime(2026, 2, 20), "Documentación irregular asociada a la mercadería", false, _casos[9]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 21), "Herramienta encontrada en una ventana forzada", true, _casos[10]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 22), "Grabación de la entrada al inmueble", 4, true, _casos[10]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 23), "Testimonio de un vecino del inmueble", "Ricardo Méndez", Credibilidad.NORMAL, _casos[10]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 24), "Grabación del perímetro del inmueble", 3, false, _casos[10]);

            AltaEvidenciaFisica(new DateTime(2026, 2, 25), "Documentos relacionados con pagos irregulares", true, _casos[11]);
            AltaEvidenciaGrabacion(new DateTime(2026, 2, 26), "Grabación de una reunión entre funcionarios", 5, false, _casos[11]);
            AltaEvidenciaTestimonio(new DateTime(2026, 2, 27), "Testimonio de un funcionario involucrado en la investigación", "Gabriel Torres", Credibilidad.ALTO, _casos[11]);
            AltaEvidenciaFisica(new DateTime(2026, 2, 28), "Dispositivo utilizado para almacenar documentación", false, _casos[11]);

            AltaEvidenciaFisica(new DateTime(2026, 3, 1), "Objeto perteneciente a la persona desaparecida", true, _casos[12]);
            AltaEvidenciaGrabacion(new DateTime(2026, 3, 2), "Grabación de una cámara ubicada en la zona", 4, true, _casos[12]);
            AltaEvidenciaTestimonio(new DateTime(2026, 3, 3), "Testimonio de una persona que vio a la víctima por última vez", "Valentina Díaz", Credibilidad.ALTO, _casos[12]);
            AltaEvidenciaFisica(new DateTime(2026, 3, 4), "Prenda encontrada durante la búsqueda", false, _casos[12]);

            AltaEvidenciaFisica(new DateTime(2026, 3, 5), "Documento con características de impresión irregular", true, _casos[13]);
            AltaEvidenciaGrabacion(new DateTime(2026, 3, 6), "Grabación del intercambio de documentación", 5, false, _casos[13]);
            AltaEvidenciaTestimonio(new DateTime(2026, 3, 7), "Testimonio de una persona que recibió la documentación", "Federico Núñez", Credibilidad.NORMAL, _casos[13]);
            AltaEvidenciaFisica(new DateTime(2026, 3, 8), "Material utilizado para realizar las falsificaciones", false, _casos[13]);

            AltaEvidenciaFisica(new DateTime(2026, 3, 9), "Fragmento de material encontrado en el lugar del incendio", true, _casos[14]);
            AltaEvidenciaGrabacion(new DateTime(2026, 3, 10), "Grabación de seguridad del lugar antes del incendio", 4, false, _casos[14]);
            AltaEvidenciaTestimonio(new DateTime(2026, 3, 11), "Testimonio de un vecino que observó el incendio", "Natalia Pérez", Credibilidad.ALTO, _casos[14]);
            AltaEvidenciaFisica(new DateTime(2026, 3, 12), "Recipiente encontrado entre los restos", false, _casos[14]);
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
