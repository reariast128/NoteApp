namespace NoteApp
{
    public class Program
    {
        public static void Main()
        {
            Usuario user = new Usuario("Yo");
            Controlador c = new Controlador(user);
            Tui t = new Tui();
            t.Run();
        }
    }
}