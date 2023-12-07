using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public static class ClienteController
    {
        public static async Task<bool> RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("--------- Registrar Cliente ---------");

            // Solicita el nombre por consola
            Console.WriteLine("Ingresar nombre:");
            string? nombre = Console.ReadLine();

            // Valida si la cadena es vacia
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("No se ingreso nombre");
                return false;
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
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    return false;
                }
                else if (contrasena.Equals(contrasena2))
                {
                    // Las contraseñas son iguales
                    try
                    {
                        await Cliente.Registrarse(nombre, email, contrasena);
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

        public static async Task<Cliente> IniciarSesionCliente()
        {
            Console.Clear();
            Console.WriteLine("--------- Iniciar Sesion Cliente ---------");
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
                Cliente cliente = await Cliente.IniciarSesion(email, contrasena);
                return cliente;
            }
        }
    }
}
