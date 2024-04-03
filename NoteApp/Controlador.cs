namespace NoteApp;

public class Controlador
{
    public Usuario usuarioActual;
    public Gui gui;

    public Controlador(Usuario usuario, Gui gui)
    {
        this.usuarioActual = usuario;
        this.gui = gui;
    }

    public void CrearCuaderno(string nombre)
    {
        this.usuarioActual.crearCuaderno(nombre);
    }

    public void EliminarCuaderno(int id)
    {
        this.usuarioActual.eliminarCuaderno(id);
    }

    public void CrearNota(int idCuaderno, string tituloNota,string contenidoNota)
    {
        this.usuarioActual.cuadernos[idCuaderno].crearNota(tituloNota, contenidoNota);
    }

    public void ModificarNota(int idCuaderno, int idNota, string contenido)
    {
        this.usuarioActual.cuadernos[idCuaderno].modificarContenidoNota(idNota, contenido);
    }

    public void EliminarNota(int idCuaderno, int idNota)
    {
        this.usuarioActual.cuadernos[idCuaderno].eliminarNota(idNota);
    }
    
}