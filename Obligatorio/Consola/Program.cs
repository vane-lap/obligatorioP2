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
                        AltaSospechoso();
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

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
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

            List<Caso> casos = miSistema.CasosPorInvestigador(email); 

            foreach (Caso unC in casos)
            {
                Console.WriteLine($"Id del caso: {unC.Id} - Nombre del caso: {unC.Nombre} - Nombre del investigador: {unC.Investigador.Nombre}");
            }
            PressToContinue();
        }

        static void AltaSospechoso()
        {

        }
       
        static void MostrarSospechososConAntecedentes()
        {
            Console.WriteLine("---- Listado de Sospechosos con Antecedentes ----");
            Console.WriteLine();
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
            PressToContinue();
        }


    }
}
