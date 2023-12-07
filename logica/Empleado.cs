using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class Empleado: Persona
    {
        public int Sueldo { get; private set; }

        public Empleado(int id, string nombre, string contrasena, string email, int sueldo) : base(id, nombre, contrasena, email)
        {
            Sueldo = sueldo;
        }

        public static async Task Registrarse(string nombre, string email, string contrasena, int sueldo)
        {
            EmpleadoDTO empleadoDTO = new EmpleadoDTO(nombre, email, contrasena, sueldo);
            EmpleadoDAO _dao = new EmpleadoDAO();

            try
            {
                await _dao.PostNew(empleadoDTO);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<Empleado> IniciarSesion(string email, string contrasena)
        {
            EmpleadoDAO _dao = new EmpleadoDAO();

            try
            {
                EmpleadoDTO empleadoDTO = await _dao.GetByCredentials(email, contrasena);
                return new Empleado(empleadoDTO.Id, empleadoDTO.Nombre, empleadoDTO.Contrasena, empleadoDTO.Email, empleadoDTO.Sueldo);
            }
            catch
            {
                throw;
            }
        }

    }
}
