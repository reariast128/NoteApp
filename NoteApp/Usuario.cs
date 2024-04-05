using Newtonsoft.Json;

namespace NoteApp
{

    public class Usuario
    {
        public string Nombre;
        public List<Cuaderno> Cuadernos;

        public Usuario(string nombre)
        {
            this.Nombre = nombre;
            this.Cuadernos = new List<Cuaderno>();
            this.CrearCuaderno("Nuevo Cuaderno");
        }

        public void CambiarNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public void CrearCuaderno(string titulo)
        {
            Cuaderno cuaderno = new Cuaderno(titulo);
            this.Cuadernos.Add(cuaderno);
        }

        public void EliminarCuaderno(int id)
        {
            this.Cuadernos.RemoveAt(id);
        }

        public void GuardarSesión()
        {
            var jsonContenido = JsonConvert.SerializeObject(this, Formatting.Indented);
            string pathHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string nombreArchivo = $".{this.Nombre}.json";
            string rutaCompleta = Path.Combine(pathHome, nombreArchivo);
            
            try
            {
                // Escribe el JSON al archivo, sobrescribiendo el archivo si existe.
                File.WriteAllText(rutaCompleta, jsonContenido);
                Console.WriteLine("Archivo JSON guardado exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió un error al guardar el archivo: {e.Message}");
            }
        }
    }
}