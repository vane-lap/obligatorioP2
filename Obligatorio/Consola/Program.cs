using Dominio;
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
                        //ListadoDeCasos();
                        break;
                    case "2":
                        Console.Clear();
                        //OpcionAltaMarca();
                        break;
                    case "3":
                        Console.Clear();
                        //OpcionAltaMarca();
                        break;
                    case "4":
                        Console.Clear();
                        ListadoDeSospechosos();
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

        static void ListadoDeSospechosos()
        {
            Console.WriteLine("---- Listado de Sospechosos ----");
            Console.WriteLine();


            List<Sospechoso> todasLasSospechosos = miSistema.Sospechosos;
            if (todasLasSospechosos.Count == 0)
            {
                MostrarError("No hay sospechosos en el sistema");
            }
            else
            {
                foreach (Sospechoso unS in todasLasSospechosos)
                {
                    Console.WriteLine(unS);
                }
            }

            PressToContinue();
        }


    }
}
