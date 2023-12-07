using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

        public ClienteDTO(string nombre, string email, string contrasena)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
        }
    }
}