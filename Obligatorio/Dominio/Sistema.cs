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
            AltaEvidenciaFisica(new DateTime(2023, 1, 10), "Arma hallada en la escena", true, _casos[0]);
            AltaEvidenciaGrabacion(new DateTime(2023, 1, 11), "Cámara de seguridad local", 4, true, _casos[0]);
            AltaEvidenciaTestimonio(new DateTime(2023, 1, 12), "Declaración del testigo principal", "Juan Pérez", Credibilidad.ALTO, _casos[0]);

            AltaEvidenciaFisica(new DateTime(2023, 2, 5), "Documentos falsificados", false, _casos[1]);
            AltaEvidenciaGrabacion(new DateTime(2023, 2, 6), "Llamada telefónica grabada", 3, false, _casos[1]);
            AltaEvidenciaTestimonio(new DateTime(2023, 2, 7), "Testimonio del contador", "María Gómez", Credibilidad.NORMAL, _casos[1]);

            AltaEvidenciaFisica(new DateTime(2023, 3, 1), "Restos de pintura en la pared", true, _casos[2]);
            AltaEvidenciaGrabacion(new DateTime(2023, 3, 2), "Video de cámara móvil", 2, true, _casos[2]);
            AltaEvidenciaTestimonio(new DateTime(2023, 3, 3), "Declaración del vecino", "Carlos López", Credibilidad.BAJO, _casos[2]);

            AltaEvidenciaFisica(new DateTime(2023, 4, 15), "Nota manuscrita con amenazas", true, _casos[3]);
            AltaEvidenciaGrabacion(new DateTime(2023, 4, 16), "Audio de correo de voz", 5, false, _casos[3]);
            AltaEvidenciaTestimonio(new DateTime(2023, 4, 17), "Testimonio de la víctima", "Ana Rodríguez", Credibilidad.ALTO, _casos[3]);

            AltaEvidenciaFisica(new DateTime(2023, 5, 20), "Tarjeta de crédito clonada", false, _casos[4]);
            AltaEvidenciaGrabacion(new DateTime(2023, 5, 21), "Grabación de cajero automático", 4, true, _casos[4]);
            AltaEvidenciaTestimonio(new DateTime(2023, 5, 22), "Declaración del cajero", "Luis Martínez", Credibilidad.NORMAL, _casos[4]);

            AltaEvidenciaFisica(new DateTime(2023, 6, 10), "Herramienta de corte encontrada", true, _casos[5]);
            AltaEvidenciaGrabacion(new DateTime(2023, 6, 11), "Video de vigilancia privada", 3, true, _casos[5]);
            AltaEvidenciaTestimonio(new DateTime(2023, 6, 12), "Testimonio del guardia de seguridad", "Pedro Sánchez", Credibilidad.ALTO, _casos[5]);

            AltaEvidenciaFisica(new DateTime(2023, 7, 1), "Prenda de vestir abandonada", true, _casos[6]);
            AltaEvidenciaGrabacion(new DateTime(2023, 7, 2), "Grabación de cámara de peaje", 1, false, _casos[6]);
            AltaEvidenciaTestimonio(new DateTime(2023, 7, 3), "Declaración de informante", "Sofia Fernández", Credibilidad.BAJO, _casos[6]);

            AltaEvidenciaFisica(new DateTime(2023, 8, 8), "Dispositivo USB incautado", false, _casos[7]);
            AltaEvidenciaGrabacion(new DateTime(2023, 8, 9), "Grabación de interceptación telefónica", 5, false, _casos[7]);
            AltaEvidenciaTestimonio(new DateTime(2023, 8, 10), "Testimonio del socio comercial", "Diego Torres", Credibilidad.NORMAL, _casos[7]);

            AltaEvidenciaFisica(new DateTime(2023, 9, 14), "Objeto contundente con marcas", true, _casos[8]);
            AltaEvidenciaGrabacion(new DateTime(2023, 9, 15), "Video de cámara vehicular", 4, true, _casos[8]);
            AltaEvidenciaTestimonio(new DateTime(2023, 9, 16), "Declaración del transeúnte", "Lucía Díaz", Credibilidad.ALTO, _casos[8]);

            AltaEvidenciaFisica(new DateTime(2023, 10, 5), "Caja con mercancía ilegal", true, _casos[9]);
            AltaEvidenciaGrabacion(new DateTime(2023, 10, 6), "Grabación de dron de vigilancia", 3, true, _casos[9]);
            AltaEvidenciaTestimonio(new DateTime(2023, 10, 7), "Testimonio del oficial de aduanas", "Jorge Ruiz", Credibilidad.ALTO, _casos[9]);

            AltaEvidenciaFisica(new DateTime(2023, 11, 12), "Cerradura forzada", true, _casos[10]);
            AltaEvidenciaGrabacion(new DateTime(2023, 11, 13), "Video de timbre inteligente", 2, false, _casos[10]);
            AltaEvidenciaTestimonio(new DateTime(2023, 11, 14), "Declaración del propietario", "Elena Morales", Credibilidad.NORMAL, _casos[10]);

            AltaEvidenciaFisica(new DateTime(2023, 12, 1), "Registro contable alterado", false, _casos[11]);
            AltaEvidenciaGrabacion(new DateTime(2023, 12, 2), "Audio de reunión confidencial", 4, false, _casos[11]);
            AltaEvidenciaTestimonio(new DateTime(2023, 12, 3), "Testimonio del auditor", "Gabriel Castro", Credibilidad.ALTO, _casos[11]);

            AltaEvidenciaFisica(new DateTime(2024, 1, 18), "Pertenencia personal hallada", true, _casos[12]);
            AltaEvidenciaGrabacion(new DateTime(2024, 1, 19), "Video de estación de trenes", 3, false, _casos[12]);
            AltaEvidenciaTestimonio(new DateTime(2024, 1, 20), "Declaración de un familiar", "Valeria Ortíz", Credibilidad.NORMAL, _casos[12]);

            AltaEvidenciaFisica(new DateTime(2024, 2, 8), "Sello oficial falsificado", false, _casos[13]);
            AltaEvidenciaGrabacion(new DateTime(2024, 2, 9), "Grabación de seguridad del banco", 5, true, _casos[13]);
            AltaEvidenciaTestimonio(new DateTime(2024, 2, 10), "Testimonio del perito calígrafo", "Fernando Silva", Credibilidad.ALTO, _casos[13]);

            AltaEvidenciaFisica(new DateTime(2024, 3, 22), "Acelerante químico encontrado", true, _casos[14]);
            AltaEvidenciaGrabacion(new DateTime(2024, 3, 23), "Video de cámara de tránsito", 4, true, _casos[14]);
            AltaEvidenciaTestimonio(new DateTime(2024, 3, 24), "Declaración del bombero a cargo", "Ricardo Ramos", Credibilidad.ALTO, _casos[14]);
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
