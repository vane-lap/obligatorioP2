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
                opcion = PedirTexto("Ingrese una opcion > ");

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Saliendo");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Saliendo");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Saliendo");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Saliendo");
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Saliendo");
                        break;
                    case "0":
                        Console.WriteLine("Saliendo");
                        break;
                    default:
                        MostrarError("ERROR: Opcion invalida");
                        PressToContinue();
                        break;
                }
            }
        }
        
        static void MostrarMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** MENU ***");
            Console.ResetColor();
            Console.WriteLine("1 - Alta de nueva marca");
            Console.WriteLine("2 - Listado de marcas");
            Console.WriteLine("3 - Listado de autos");
            Console.WriteLine("4 - Autos mayores a un año");
            Console.WriteLine("5 - Autos por marca");
            Console.WriteLine("0 - Salir");
        }
        
        static void PressToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
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
            Console.ResetColor();
        }

        static string PedirTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }
        
        static int PedirEntero(string mensaje)
        {
            Console.Write(mensaje);
            string enteroString = Console.ReadLine();
            int enteroConvertido = 0;

            while (!int.TryParse(enteroString, out enteroConvertido))
            {
                MostrarError("ERROR DE INGRESO");
                Console.Write(mensaje);
                enteroString = Console.ReadLine();
            }

            return enteroConvertido;
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
    }
}
