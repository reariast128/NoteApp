using System;
using System.IO;
using Newtonsoft.Json;
using Program; // Esto asume que la clase Usuario está bajo el namespace Program

namespace Program
{
    class Program
    {
        static void Main()
        {
            Usuario usuario = null;

            string pathHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string nombreArchivo = ".Juan.json";
            string userFilePath = Path.Combine(pathHome, nombreArchivo);
            try
            {
                // Lee el contenido del archivo como una cadena.
                string contenidoJson = File.ReadAllText(userFilePath);
                
                // Deserializa usando JsonConvert de Newtonsoft.Json
                usuario = JsonConvert.DeserializeObject<Usuario>(contenidoJson);
            }
            catch (FileNotFoundException e)
            {
                // Manejo de excepción en caso de que el archivo no exista.
                Console.WriteLine($"{nombreArchivo} no encontrado. Creando un nuevo usuario.");
                usuario = new Usuario("Juan");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió un error: {e.Message}");
            }

            Controlador c = new Controlador(usuario);
            Tui t = new Tui(c);
            t.Run();
        }
    }

}