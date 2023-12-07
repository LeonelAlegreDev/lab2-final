using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int Sueldo { get; set; }

        public EmpleadoDTO(string nombre, string email, string contrasena, int sueldo)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
            Sueldo = sueldo;
        }
    }

}
