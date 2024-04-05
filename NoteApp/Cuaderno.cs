namespace NoteApp
{
    public class Cuaderno
    {
        public string Titulo;
        public DateTime HoraCreacion;
        public DateTime HoraModificacion;
        public List<Nota> Notas;

        public Cuaderno(string titulo)
        {
            this.Titulo = titulo;
            this.HoraCreacion = DateTime.Now;
            this.HoraModificacion = DateTime.Now;
            this.Notas = new List<Nota>();
            this.CrearNota("Nueva nota", "veamos que pasa");
        }

        public void CrearNota(string titulo, string contenido)
        {
            this.Notas.Add(new Nota(titulo, contenido));
            this.HoraModificacion = DateTime.Now;
        }

        public void EliminarNota(int id)
        {
            this.Notas.RemoveAt(id);
            this.HoraModificacion = DateTime.Now;
        }

        public void ModificarContenidoNota(int id, string contenido)
        {
            this.Notas[id].Contenido = contenido;
            this.Notas[id].HoraModificacion = DateTime.Now;
            this.HoraModificacion = DateTime.Now;
        }

        public void ModificarTituloNota(int id, string titulo)
        {
            this.Notas[id].Titulo = titulo;
            this.Notas[id].HoraModificacion = DateTime.Now;
            this.HoraModificacion = DateTime.Now;
        }

        public void ModificarTitulo(string titulo)
        {
            this.Titulo = titulo;
            this.HoraModificacion = DateTime.Now;
        }
    }
}