using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public static class EmpleadoController
    {
        public static async Task<bool> RegistrarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("--------- Registrar Empleado ---------");

            // Solicita el nombre por consola
            Console.WriteLine("Ingresar nombre:");
            string? nombre = Console.ReadLine();

            // Valida si la cadena es vacia
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("No se ingreso nombre");
                return false;
            }

            // Solicita el nombre por consola
            Console.WriteLine("Ingresar sueldo:");
            string? sueldo = Console.ReadLine();
            int parsed_sueldo;
            // Valida si la cadena es vacia
            if (string.IsNullOrWhiteSpace(sueldo))
            {
                Console.WriteLine("No se ingreso sueldo");
                return false;
            }
            else
            {
                // Valida si es un entero
                bool isInt = int.TryParse(sueldo, out int resultado);
                if (isInt == false)
                {
                    Console.WriteLine("Sueldo no es un entero");
                    return false;
                }
                parsed_sueldo = resultado;
            }

            // Solicita el email por consola
            Console.WriteLine("Ingresar email:");
            string? email = Console.ReadLine();

            // Valida si la cadena es vacia
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("No se ingreso email");
                return false;
            }

            // Solicita la contraseña por consola
            Console.WriteLine("Ingresar contrasena:");
            string? contrasena = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                Console.WriteLine("No se ingreso contrasena");
                return false;
            }
            else
            {
                Console.WriteLine("Repetir contrasena:");
                string? contrasena2 = Console.ReadLine();

                // Valida que se haya reingresado contraseña
                if (string.IsNullOrWhiteSpace(contrasena))
                {
                    Console.WriteLine("No se reingreso contrasena");
                    return false;
                }
                else if (contrasena.Equals(contrasena2))
                {
                    // Las contraseñas son iguales
                    try
                    {
                        await Empleado.Registrarse(nombre, email, contrasena, parsed_sueldo);
                        Console.WriteLine("Datos cargados correctamente");
                        return true;
                    }
                    catch
                    {
                        Console.WriteLine("Algo salio mal");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Las contrasenas no son iguales");
                    return false;
                }
            }
        }

        public static async Task<Empleado> IniciarSesionEmpleado()
        {
            Console.Clear();
            Console.WriteLine("--------- Iniciar Sesion Empleado ---------");
            // Solicita el email por consola
            Console.WriteLine("Ingresar email:");
            string? email = Console.ReadLine();

            // Valida si la cadena es vacia
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("No se ingreso email");
            }

            // Solicita la contraseña por consola
            Console.WriteLine("Ingresar contrasena:");
            string? contrasena = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new Exception("No se ingreso contrasena");
            }
            else
            {
                // Se inicia sesion
                Empleado empleado = await Empleado.IniciarSesion(email, contrasena);
                return empleado;
            }
        }

    }
}
