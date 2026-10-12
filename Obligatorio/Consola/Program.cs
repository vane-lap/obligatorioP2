using Dominio;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Consola
{
    internal class Program
    {
        private static Sistema miSistema;
        static void Main(string[] args)
        {
            miSistema = new Sistema();
            string opcion = "";
            while (opcion != "0")
            {
                MostrarMenu();
                opcion = PedirTexto("Ingrese una opción > ");

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        MostrarListadoCasos();
                        break;
                    case "2":
                        Console.Clear();
                        BuscadorDeCasosPorInvestigador();
                        break;
                    case "3":
                        Console.Clear();
                        CrearSospechoso();
                        break;
                    case "4":
                        Console.Clear();
                        MostrarSospechososConAntecedentes();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo");
                        break;
                    default:
                        MostrarError("ERROR: Opción inválida");
                        PressToContinue();
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** MENÚ ***");
            Console.ResetColor();
            Console.WriteLine("1 - Listado de casos");
            Console.WriteLine("2 - Buscar caso por investigador");
            Console.WriteLine("3 - Dar de alta a un sospechoso");
            Console.WriteLine("4 - Listado de sospechosos");
            Console.WriteLine("0 - Salir");
        }

        static string PedirTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }

        static DateTime LeerFecha(string mensaje)
        {
            bool exito = false;
            DateTime fecha = new DateTime();
            while (!exito)
            {
                Console.Write(mensaje + " [DD/MM/YYYY]:");
                exito = DateTime.TryParse(Console.ReadLine(), out fecha);

                if (!exito) MostrarError("ERROR: Debe ingresar una fecha en formato DD/MM/YYYY");
            }
            return fecha;
        }

        static bool LeerBooleano(string mensaje)
        {
            bool exito = false;
            bool resultado = false;
            while (!exito)
            {
                Console.Write(mensaje + " [S/N]:");
                string booleanoString = Console.ReadLine();
                if (booleanoString.ToUpper() == "S")
                {
                    resultado = true;
                    exito = true;
                }
                else if (booleanoString.ToUpper() == "N")
                {
                    resultado = false;
                    exito = true;
                }

                if (!exito) MostrarError("ERROR: Debe ingresar solo S o N");
            }

            return resultado;
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void PressToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para volver al menú");
            Console.ReadKey();
        }

        static void MostrarListadoCasos()
        {
            Console.WriteLine("---- Listado de Casos ----");
            Console.WriteLine();
            foreach (Caso unC in miSistema.Casos)
            {
                Console.WriteLine(unC);
            }
            PressToContinue();
        }

        static void BuscadorDeCasosPorInvestigador()
        {
            string email = PedirTexto("Ingrese un mail: ");
            try
            {
                List<Caso> casos = miSistema.CasosPorInvestigador(email);
                foreach (Caso unC in casos)
                {
                    Console.WriteLine($"Id del caso: {unC.Id} - Nombre del caso: {unC.Nombre} - Nombre del investigador: {unC.Investigador.Nombre}");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            PressToContinue();
        }

        static void CrearSospechoso()
        {
            string nombre = PedirTexto("Ingrese su nombre: ");
            string cedula = PedirTexto("Ingrese su cedula: ");
            DateTime fechaNac = LeerFecha("Ingrese su fecha de nacimiento: ");
            bool tieneAntecedente = LeerBooleano("Tiene antecedentes? ");

            try
            {
                miSistema.AltaSospechoso(nombre, cedula, fechaNac, tieneAntecedente);
                MostrarExito("Sospechoso creado correctamente");
            }
            catch(Exception ex)
            {
                MostrarError(ex.Message);
            }
            PressToContinue();
        }

        static void MostrarSospechososConAntecedentes()
        {
            Console.WriteLine("---- Listado de Sospechosos con Antecedentes ----");
            Console.WriteLine();
            try
            {
                List<Sospechoso> todosLosSospechososConAntecedentes = miSistema.ObtenerSospechososConAntecedentes();
                if (todosLosSospechososConAntecedentes.Count == 0)
                {
                    MostrarError("No hay sospechosos con antecedentes en el sistema");
                }
                else
                {
                    foreach (Sospechoso unS in todosLosSospechososConAntecedentes)
                    {
                        Console.WriteLine(unS);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            PressToContinue();
        }
    }
}
