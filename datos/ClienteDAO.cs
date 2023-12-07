using MySql.Data.MySqlClient;

namespace Datos
{
    public class ClienteDAO : IDAO<ClienteDTO>
    {
        //private string _conexion = "Data Source=localhost;Initial Catalog=lab2;User ID=root;Password=secret_password";
        private string connectionString = "server=localhost;database=lab2;uid=root;pwd=secret_password;";

        bool IDAO<ClienteDTO>.DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        List<ClienteDTO> IDAO<ClienteDTO>.GetAll()
        {
            throw new NotImplementedException();
        }

        ClienteDTO IDAO<ClienteDTO>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteDTO> GetByCredentials(string email, string contrasena)
        {
            // Conectarse a la base de datos
            MySqlConnection cnn = new MySqlConnection(connectionString); ;
            await cnn.OpenAsync();

            // Prerara la consulta
            MySqlCommand command = new MySqlCommand("SELECT * FROM clientes WHERE email = @email AND contrasena = @contrasena;", cnn);

            // Establecer los valores de los parámetros de la consulta
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@contrasena", contrasena);
            try
            {
                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Mapear los resultados a la clase ClienteDTO
                        ClienteDTO cliente = new ClienteDTO(reader.GetString("nombre"), reader.GetString("email"), reader.GetString("contrasena"));
                        cliente.Id = reader.GetInt32("id");

                        return cliente;
                    }
                }
                throw new Exception("Fallo la ejecucion al obtener Cliente");
            }
            catch
            {
                throw;
                throw new Exception("Fallo la ejecucion al obtener Cliente");
            }
        }

        public async Task<ClienteDTO> PostNew(ClienteDTO entity)
        {
            // Conectarse a la base de datos
            MySqlConnection cnn = new MySqlConnection(connectionString); ;
            await cnn.OpenAsync();

            // Prerara la consulta
            MySqlCommand command = new MySqlCommand("INSERT INTO clientes (nombre, email, contrasena) VALUES (@nombre, @email, @contrasena); SELECT LAST_INSERT_ID();", cnn);
            
            // Establecer los valores de los parámetros de la consulta
            command.Parameters.AddWithValue("@nombre", entity.Nombre);
            command.Parameters.AddWithValue("@email", entity.Email);
            command.Parameters.AddWithValue("@contrasena", entity.Contrasena);

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
                throw new Exception("Fallo la ejecucion al cargar Cliente");
            }

            // Cerrar la conexión a la base de datos
            cnn.Close();

            // Devolver el nuevo cliente
            return entity;
        }

        bool IDAO<ClienteDTO>.UpdateById(int id, ClienteDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}