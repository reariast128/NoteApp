using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using Terminal.Gui.Trees;

namespace NoteApp;

class Tui
{
    private Controlador _controlador;
    private Regex _esC;
    private Regex _esNumero;
    private Regex _esQ;
    public Tui(Controlador controlador)
    {
        _controlador = controlador;
        _esC = new Regex(@"^[c|C]$");
        _esQ = new Regex(@"^[q|Q]$");
        _esNumero = new Regex(@"^\d+$");
    }

    public void Run()
    {
        Bienvenida();
        string opcion = MenuOpciones();

        if (ValidarOpcion(opcion) && (opcion == "c" || opcion == "C"))
        { 
            CrearCuaderno();
        } else if (ValidarOpcion(opcion) && (opcion == "q" || opcion == "Q"))
        {
            Salir();
        } else if (ValidarOpcion(opcion))
        {
            SeleccionarCuaderno(opcion);
        }
        else
        {
            Console.WriteLine("No has seleccionado una opción válida. Por favor, valida tu opción.");
        }

    }

    private void Bienvenida()
    {
        Console.WriteLine("Bienvenido a NoteAppp, tu aplicación de notas de confianza.");
    }

    private string MenuOpciones()
    {
        Console.WriteLine("Estos son los cuadernos disponibles. Selecciona uno indicando el id, o pon 'c' para crear uno nuevo");

        string opcion;
        var cuadernos = _controlador.ObtenerTitulosCuaderno();

        for (int i = 0; i < cuadernos.Count, i++)
        {
            Console.WriteLine($"({i}) {cuadernos[i]}");
        };

        opcion = Console.ReadLine();

        return opcion;
    }

    private bool ValidarOpcion(string opcion)
    {
        if(_esC.IsMatch(opcion) || _esQ.IsMatch(opcion) || _esNumero.IsMatch(opcion))
        {
            return true;
        } else 
        {
            return false;
        }

    }

    private void SeleccionarCuaderno(string opcion)
    {

        string tituloCuaderno = _controlador.ObtenerTitulosNotasCuaderno[opcion]
    }

    private void CrearCuaderno()
    {

    }

    private void Salir()
    {
        Environment.Exit(0);
    }
}