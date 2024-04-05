namespace NoteApp
{

    public class Nota
    {
        public DateTime HoraCreacion;
        public DateTime HoraModificacion;
        public string Titulo;
        public string Contenido;

        public Nota(string titulo, string contenido)
        {
            this.Titulo = titulo;
            this.Contenido = contenido;
            this.HoraCreacion = DateTime.Now;
            this.HoraModificacion = DateTime.Now;
        }

    }
}