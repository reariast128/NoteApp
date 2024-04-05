namespace NoteApp;

public class Nota
{
    public DateTime horaCreacion;
    public DateTime horaModificacion;
    public string titulo;
    public string contenido;

    public Nota(string titulo, string contenido)
    {
        this.titulo = titulo;
        this.contenido = contenido;
        this.horaCreacion = DateTime.Now;
        this.horaModificacion = DateTime.Now;
    }
    
}