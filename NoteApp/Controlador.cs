namespace NoteApp;

public class Controlador
{
    public Usuario usuarioActual;
    public Gui gui;

    public Controlador(Usuario usuario)
    {
        this.usuarioActual = usuario;
    }

    public void CrearCuaderno(string nombre)
    {
        this.usuarioActual.crearCuaderno(nombre);
    }
}