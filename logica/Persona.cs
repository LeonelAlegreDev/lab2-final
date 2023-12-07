namespace Logica.Clases
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }


        public Persona(int id, string nombre, string contrasena, string email)
        {
            Id = id;
            Nombre = nombre;
            Contrasena = contrasena;
            Email = email;
        }
    }
}