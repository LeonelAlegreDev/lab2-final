using Logica.Clases;
using static Aplicacion.EmpleadoController;
using static Aplicacion.ClienteController;

class Program
{
    static async Task Main()
    {
        bool salir = false;
        Persona? usuario = null;
       
        do
        {
            MostrarMenu();
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    try
                    {
                        await RegistrarCliente();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    try
                    {
                        usuario = await IniciarSesionCliente();
                        Console.WriteLine("Inicio de sesion exitoso");
                        Console.WriteLine("Bienvenido " + usuario.Nombre + "!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    try
                    {
                        await RegistrarEmpleado();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "4":
                    try
                    {
                        usuario = await IniciarSesionEmpleado();
                        Console.WriteLine("Inicio de sesion exitoso");
                        Console.WriteLine("Bienvenido " + usuario.Nombre + "!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "9":
                    Console.Clear();
                    Console.WriteLine("Confirme si desea salir (S para salir):");
                    if (Console.ReadKey().KeyChar == 'S' || Console.ReadKey().KeyChar == 's')
                        salir = true;
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (!salir);
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("--------- Menú de Selección ---------");
        Console.WriteLine("1. Registrar Cliente");
        Console.WriteLine("2. Iniciar Sesion Cliente");
        Console.WriteLine("3. Registrar Empleado");
        Console.WriteLine("4. Iniciar Sesion Empleado");
        Console.WriteLine("9. Salir");
        Console.Write("Seleccione una opción: ");
    }

}