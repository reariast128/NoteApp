using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace NoteApp;

public class Controlador
{
    public Usuario usuarioActual;

    public Controlador(Usuario usuario)
    {
        this.usuarioActual = usuario;
    }

    public void CrearCuaderno(string nombre)
    {
        this.usuarioActual.crearCuaderno(nombre);
    }

    public void EliminarCuaderno(int id)
    {
        this.usuarioActual.eliminarCuaderno(id);
    }

    public void ModificarTituloCuaderno(int idCuaderno, string titulo)
    {
        this.usuarioActual.cuadernos[idCuaderno].modificarTitulo(titulo);
    }

    public void CrearNota(int idCuaderno, string tituloNota, string contenidoNota)
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

    public void ModificarTituloNota(int idCuaderno, int idNota, string titulo)
    {
        this.usuarioActual.cuadernos[idCuaderno].modificarTituloNota(idNota, titulo);
    }

    public string ObtenerNombreUsuario => this.usuarioActual.nombre;

    public List<string> ObtenerTitulosCuaderno()
    {
        List<string> titulosCuadernos = new List<string>();

        foreach (var cuaderno in this.usuarioActual.cuadernos)
        {
            titulosCuadernos.Add(cuaderno.titulo);
        }

        return titulosCuadernos;
    }

    public List<String> ObtenerTitulosNotasCuaderno(int idCuaderno)
    {
        List<String> titulosNotas = new List<string>();

        foreach (var nota in this.usuarioActual.cuadernos[idCuaderno].notas)
        {
            titulosNotas.Add(nota.titulo);
        }

        return titulosNotas;
    }

    public DateTime ObtenerFechaCreacionCuaderno(int idCuaderno) =>
        this.usuarioActual.cuadernos[idCuaderno].horaCreacion;
    
    public DateTime ObtenerFechaModificacionCuaderno(int idCuaderno) =>
        this.usuarioActual.cuadernos[idCuaderno].horaModificacion;
    
    public string ObtenerContenidoNota(int idCuaderno, int idNota) =>
        this.usuarioActual.cuadernos[idCuaderno].notas[idNota].contenido;
    
    public DateTime ObtenerFechaCreacionNota(int idCuaderno, int idNota) =>
        this.usuarioActual.cuadernos[idCuaderno].notas[idNota].horaCreacion;
    
    public DateTime ObtenerFechaModificacionNota(int idCuaderno, int idNota) =>
        this.usuarioActual.cuadernos[idCuaderno].notas[idNota].horaModificacion;
}