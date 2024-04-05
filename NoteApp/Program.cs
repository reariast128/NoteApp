namespace NoteApp
{
    public class Program
    {
        public static void Main()
        {
            Usuario user = new Usuario("Yo");
            Controlador c = new Controlador(user);
            c.CrearCuaderno("Segundo cuaderno");
            Tui t = new Tui(c);
            t.Run();
        }
    }
}