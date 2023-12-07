using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDAO : IDAO<EmpleadoDTO>
    {
        //private string _conexion = "Data Source=localhost;Initial Catalog=lab2;User ID=root;Password=secret_password";
        private string connectionString = "server=localhost;database=lab2;uid=root;pwd=secret_password;";

        bool IDAO<EmpleadoDTO>.DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        List<EmpleadoDTO> IDAO<EmpleadoDTO>.GetAll()
        {
            throw new NotImplementedException();
        }

        EmpleadoDTO IDAO<EmpleadoDTO>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmpleadoDTO> GetByCredentials(string email, string contrasena)
        {
            // Conectarse a la base de datos
            MySqlConnection cnn = new MySqlConnection(connectionString); ;
            await cnn.OpenAsync();

            // Prerara la consulta
            MySqlCommand command = new MySqlCommand("SELECT * FROM empleados WHERE email = @email AND contrasena = @contrasena;", cnn);

            // Establecer los valores de los parámetros de la consulta
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@contrasena", contrasena);
            try
            {
                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Mapear los resultados a la clase EmpleadoDTO
                        EmpleadoDTO empleadoDTO = new EmpleadoDTO(reader.GetString("nombre"), reader.GetString("email"), reader.GetString("contrasena"), reader.GetInt32("sueldo"));
                        empleadoDTO.Id = reader.GetInt32("id");

                        return empleadoDTO;
                    }
                }
                throw new Exception("Fallo la ejecucion al obtener Empleado");
            }
            catch
            {
                throw;
                throw new Exception("Fallo la ejecucion al obtener Cliente");
            }
        }

        public async Task<EmpleadoDTO> PostNew(EmpleadoDTO entity)
        {
            // Conectarse a la base de datos
            MySqlConnection cnn = new MySqlConnection(connectionString); ;
            await cnn.OpenAsync();

            // Prerara la consulta
            MySqlCommand command = new MySqlCommand("INSERT INTO empleados (nombre, email, contrasena, sueldo) VALUES (@nombre, @email, @contrasena, @sueldo); SELECT LAST_INSERT_ID();", cnn);

            // Establecer los valores de los parámetros de la consulta
            command.Parameters.AddWithValue("@nombre", entity.Nombre);
            command.Parameters.AddWithValue("@email", entity.Email);
            command.Parameters.AddWithValue("@contrasena", entity.Contrasena);
            command.Parameters.AddWithValue("@sueldo", entity.Sueldo);

            // Ejecutar la consulta
            try
            {
                //Ejecuta la consulta y Actualiza el ID de la entidad por el generado por la base de datos
                int lastId = Convert.ToInt32(await command.ExecuteScalarAsync());
                entity.Id = lastId;
            }
            catch
            {
                // Lanzar el error
                throw new Exception("Fallo la ejecucion al cargar Empleado");
            }

            // Cerrar la conexión a la base de datos
            cnn.Close();

            // Devolver el nuevo objeto
            return entity;
        }

        bool IDAO<EmpleadoDTO>.UpdateById(int id, EmpleadoDTO entity)
        {
            throw new NotImplementedException();
        }
    }

}
