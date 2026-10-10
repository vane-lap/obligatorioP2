namespace Consola;

internal class Program
{
    private static Sistema miSistema;

    private static void Main(string[] args)
    {
        miSistema = new Sistema();
        var opcion = "";
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

    private static void MostrarMenu()
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

    private static string PedirTexto(string mensaje)
    {
        Console.Write(mensaje);
        var texto = Console.ReadLine();
        return texto;
    }

    private static DateTime LeerFecha(string mensaje)
    {
        var exito = false;
        var fecha = new DateTime();
        while (!exito)
        {
            Console.Write(mensaje + " [DD/MM/YYYY]:");
            exito = DateTime.TryParse(Console.ReadLine(), out fecha);

            if (!exito) MostrarError("ERROR: Debe ingresar una fecha en formato DD/MM/YYYY");
        }

        return fecha;
    }

    private static bool LeerBooleano(string mensaje)
    {
        var exito = false;
        var resultado = false;
        while (!exito)
        {
            Console.Write(mensaje + " [S/N]:");
            var booleanoString = Console.ReadLine();
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

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }

    private static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static void PressToContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Presione cualquier tecla para volver al menú");
        Console.ReadKey();
    }

    private static void MostrarListadoCasos()
    {
        Console.WriteLine("---- Listado de Casos ----");
        Console.WriteLine();
        foreach (Caso unC in miSistema.Casos) Console.WriteLine(unC);
        PressToContinue();
    }

    private static void BuscadorDeCasosPorInvestigador()
    {
        var email = PedirTexto("Ingrese un mail: ");

        List<Caso> casos = miSistema.CasosPorInvestigador(email);

        foreach (Caso unC in casos)
            Console.WriteLine(
                $"Id del caso: {unC.Id} - Nombre del caso: {unC.Nombre} - Nombre del investigador: {unC.Investigador.Nombre}");
        PressToContinue();
    }


    private static void CrearSospechoso()
    {
        var nombre = PedirTexto("Ingrese su nombre: ");
        var cedula = PedirTexto("Ingrese su cedula: ");
        var fechaNac = LeerFecha("Ingrese su fecha de nacimiento: ");
        var tieneAntecedente = LeerBooleano("Tiene antecedentes? ");d

        try
        {
            miSistema.AltaSospechoso(nombre, cedula, fechaNac, tieneAntecedente);
            MostrarExito("Sospechoso creado correctamente");
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }

        PressToContinue();
    }

    private static void MostrarSospechososConAntecedentes()
    {
        Console.WriteLine("---- Listado de Sospechosos con Antecedentes ----");
        Console.WriteLine();
        List<Sospechoso> todosLosSospechososConAntecedentes = miSistema.ObtenerSospechososConAntecedentes();
        if (todosLosSospechososConAntecedentes.Count == 0)
            MostrarError("No hay sospechosos con antecedentes en el sistema");
        else
            foreach (Sospechoso unS in todosLosSospechososConAntecedentes)
                Console.WriteLine(unS);

        PressToContinue();
    }
}