namespace NoteApp;

public class Usuario
{
    public string nombre;
    public List<Cuaderno> cuadernos;

    public Usuario(string nombre)
    {
        this.nombre = nombre;
        this.cuadernos = new List<Cuaderno>();
        this.cuadernos.Add(new Cuaderno("Nuevo Cuaderno"));
    }

    public void cambiarNombre(string nombre)
    {
        this.nombre = nombre;
        
    }

    public void crearCuaderno(string titulo)
    {
        Cuaderno cuaderno = new Cuaderno(titulo);
        this.cuadernos.Add(cuaderno);
    }

    public void eliminarCuaderno(int id)
    {
        this.cuadernos.RemoveAt(id);
    }
}