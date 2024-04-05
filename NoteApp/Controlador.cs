namespace NoteApp
{

    public class Controlador
    {
        public Usuario UsuarioActual;

        public Controlador(Usuario usuario)
        {
            this.UsuarioActual = usuario;
        }

        public void CrearCuaderno(string nombre)
        {
            this.UsuarioActual.CrearCuaderno(nombre);
        }

        public void EliminarCuaderno(int id)
        {
            this.UsuarioActual.EliminarCuaderno(id);
        }

        public void ModificarTituloCuaderno(int idCuaderno, string titulo)
        {
            this.UsuarioActual.Cuadernos[idCuaderno].ModificarTitulo(titulo);
        }

        public void CrearNota(int idCuaderno, string tituloNota, string contenidoNota)
        {
            this.UsuarioActual.Cuadernos[idCuaderno].CrearNota(tituloNota, contenidoNota);
        }

        public void ModificarNota(int idCuaderno, int idNota, string contenido)
        {
            this.UsuarioActual.Cuadernos[idCuaderno].ModificarContenidoNota(idNota, contenido);
        }

        public void EliminarNota(int idCuaderno, int idNota)
        {
            this.UsuarioActual.Cuadernos[idCuaderno].EliminarNota(idNota);
        }

        public void ModificarTituloNota(int idCuaderno, int idNota, string titulo)
        {
            this.UsuarioActual.Cuadernos[idCuaderno].ModificarTituloNota(idNota, titulo);
        }

        public string ObtenerNombreUsuario => this.UsuarioActual.Nombre;

        public List<string> ObtenerTitulosCuaderno()
        {
            List<string> titulosCuadernos = new List<string>();

            foreach (var cuaderno in this.UsuarioActual.Cuadernos)
            {
                titulosCuadernos.Add(cuaderno.Titulo);
            }

            return titulosCuadernos;
        }

        public List<String> ObtenerTitulosNotasCuaderno(int idCuaderno)
        {
            List<String> titulosNotas = new List<string>();

            foreach (var nota in this.UsuarioActual.Cuadernos[idCuaderno].Notas)
            {
                titulosNotas.Add(nota.Titulo);
            }

            return titulosNotas;
        }

        public DateTime ObtenerFechaCreacionCuaderno(int idCuaderno) =>
            this.UsuarioActual.Cuadernos[idCuaderno].HoraCreacion;

        public DateTime ObtenerFechaModificacionCuaderno(int idCuaderno) =>
            this.UsuarioActual.Cuadernos[idCuaderno].HoraModificacion;

        public string ObtenerContenidoNota(int idCuaderno, int idNota) =>
            this.UsuarioActual.Cuadernos[idCuaderno].Notas[idNota].Contenido;

        public DateTime ObtenerFechaCreacionNota(int idCuaderno, int idNota) =>
            this.UsuarioActual.Cuadernos[idCuaderno].Notas[idNota].HoraCreacion;

        public DateTime ObtenerFechaModificacionNota(int idCuaderno, int idNota) =>
            this.UsuarioActual.Cuadernos[idCuaderno].Notas[idNota].HoraModificacion;

        public Cuaderno SeleccionarCuaderno(int idCuaderno) =>
            this.UsuarioActual.Cuadernos[idCuaderno];

        public Nota SeleccionarNota(int idCuaderno, int idNota) =>
            this.UsuarioActual.Cuadernos[idCuaderno].Notas[idNota];
    }
}