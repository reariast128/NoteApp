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
        // Expresión regular que valida si un string contiene únicamente c o C
        _esC = new Regex(@"^(c|C)$");
        // Expresión regular que valida si un string contiene únicamente q o Q
        _esQ = new Regex(@"^(q|Q)$");
        // Expresión regular que valida si un string contiene más de un dígito.
        _esNumero = new Regex(@"^\d+$");
    }

    public void Run()
    {
        /* Función principal que ejecuta el programa. */
        Bienvenida();


        while (true)
        {
            string opcion = MenuDeOpciones();
            // Se valida si la opción introducida por el usuario es c para crear un cuaderno.
            if (ValidarOpcion(opcion) && (opcion == "c" || opcion == "C"))
            {
                CrearCuaderno();
            }
            // Se valida si la opción introducida por el usuario es q para salir del programa.
            else if (ValidarOpcion(opcion) && (opcion == "q" || opcion == "Q"))
            {
                Salir();
            }
            // Si no es c ni es q, pero sigue siendo verdadero, es porque es un número.
            else if (ValidarOpcion(opcion))
            {
                SeleccionarCuaderno(opcion);
            }
            // Por descarte, ninguna opción es válida
            else
            {
                Console.WriteLine("No has seleccionado una opción válida. Por favor, valida tu opción.");
            }
            
            
        }
    }

    private void Bienvenida()
    {
        Console.WriteLine("Bienvenido a NoteAppp, tu aplicación de notas de confianza.");
    }

    private string MenuDeOpciones()
    {
        Console.WriteLine(
            "Estos son los cuadernos disponibles. Selecciona uno indicando el id, o pon 'c' para crear uno nuevo");

        string opcion;
        var cuadernos = _controlador.ObtenerTitulosCuaderno();

        for (int i = 0; i < cuadernos.Count; i++)
        {
            Console.WriteLine($"({i}) {cuadernos[i]}");
        }

        ;

        opcion = Console.ReadLine();

        return opcion;
    }

    private bool ValidarOpcion(string opcion)
        /* Esta función valida si la opción contiene 'c' o 'C', 'q' o 'Q', o si el string contiene números. */
    {
        if (_esC.IsMatch(opcion) || _esQ.IsMatch(opcion) || _esNumero.IsMatch(opcion))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SeleccionarCuaderno(string opcion)
    {
        try
        {
            Int128 id = Int128.Parse(opcion);

        }
        catch (Exception)
        {
            Console.WriteLine("Algo pasó que no pudimos seleccionar el cuaderno :(");
        }
    }

    private void CrearCuaderno()
    {
        Console.WriteLine("");
    }

    private void Salir()
    {
        Environment.Exit(0);
    }
}