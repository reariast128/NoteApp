namespace NoteApp
{
    public class Cuaderno
    {
        public string titulo;
        public DateTime horaCreacion;
        public DateTime horaModificacion;
        public List<Nota> notas;

        public Cuaderno(string titulo)
        {
            this.titulo = titulo;
            this.horaCreacion = DateTime.Now;
            this.horaModificacion = DateTime.Now;
            this.notas.Append(new Nota("Nueva nota", ""));
        }

        public void crearNota(string titulo, string contenido)
        {
            Nota nota = new Nota(titulo, contenido);
            this.notas.Add(nota);
            this.horaModificacion = DateTime.Now;
        }

        public void eliminarNota(int id)
        {
            this.notas.RemoveAt(id);
            this.horaModificacion = DateTime.Now;
        }

        public void modificarContenidoNota(int id, string contenido)
        {
            this.notas[id].contenido = contenido;
            this.notas[id].horaModificacion = DateTime.Now;
            this.horaModificacion = DateTime.Now;
        }

        public void modificarTituloNota(int id, string titulo)
        {
            this.notas[id].titulo = titulo;
            this.notas[id].horaModificacion = DateTime.Now;
            this.horaModificacion = DateTime.Now;
        }

        public void modificarTitulo(string titulo)
        {
            this.titulo = titulo;
            this.horaModificacion = DateTime.Now;
        }

    }
}