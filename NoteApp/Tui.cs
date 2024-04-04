using Terminal.Gui;

namespace NoteApp;

class Tui
{
    private ColorScheme _appColorScheme;
    private Window _mainWin;
    private Controlador _controlador;
    private View _cuadernosContentRect;
    private FrameView _cuadernosRect;
    private FrameView _notasRect;

    public Tui(Controlador controlador)
    {
        _appColorScheme = new ColorScheme()
        {
            Normal = Terminal.Gui.Attribute.Make(Color.BrightGreen, Color.Black),
            Focus = Terminal.Gui.Attribute.Make(Color.Black, Color.Gray),
            HotNormal = Terminal.Gui.Attribute.Make(Color.BrightYellow, Color.DarkGray),
            HotFocus = Terminal.Gui.Attribute.Make(Color.BrightYellow, Color.Black),
        };

        _mainWin = new Window("Ventana Principal")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1,
            ColorScheme = _appColorScheme, // Aplica el esquema de colores a la ventana principal
        };

        _cuadernosContentRect = new View()
        {
            Width = Dim.Fill(), // Ajuste para que ocupe el ancho completo del FrameView
            Height = Dim.Fill() // Ajuste para que ocupe el alto completo del FrameView
        };

        // FrameView que actúa como rectángulo con bordes
        _cuadernosRect = new FrameView("Cuadernos")
        {
            X = Pos.Percent(0), // Alineado completamente a la izquierda
            Y = Pos.At(0), // Comienza en la parte superior
            Width = 30, // Un ancho fijo por ahora, ajusta según necesites
            Height = Dim.Fill(), // Ocupa todo el alto disponible
            ColorScheme = _appColorScheme,
        };
        
        _notasRect = new FrameView("Notas")
        {
            X = Pos.Right(_cuadernosRect) + 1,  // Asume que `cuadernosRect` se coloca a la izquierda.
            Y = Pos.Top(_mainWin),
            Width = 40,  // O el ancho que prefieras.
            Height = Dim.Fill(),  // Para ocupar el alto disponible.
            ColorScheme = _appColorScheme,
        };

        _controlador = controlador;
    }

    public void Run()
    {
        Application.Init();
        var top = Application.Top;

        Application.Top.ColorScheme = _appColorScheme;

        // Crea la ventana principal

        top.Add(_mainWin);

        // Dimensiones compartidas para los rectángulos
        int spacing = 2;

        DibujarRectangulosMenu(spacing);

        Application.Run();
    }

    private void DibujarRectangulosMenu(int espaciado)
    {
        var cuadernos = _controlador.ObtenerTitulosCuaderno();
        int posY = 1; // Iniciamos en 1 para dar un margen superior dentro del rectángulo contenido


        // Añadir los botones para cada cuaderno
        for (int i = 0; i < cuadernos.Count; i++)
        {
            var cuaderno = cuadernos[i];
            var botonCuaderno = new Button(cuaderno)
            {
                X = Pos.At(2), // Margen izquierdo dentro del cuadernosRect
                Y = Pos.At(posY),
                Height = 1,
            };

            // Este es el cambio clave: almacenar el índice actual de cuaderno en una variable local para el delegado
            int idCuaderno = i;

            botonCuaderno.Clicked += () =>
            {
                // Aquí puedes llamar a la función que actualiza y muestra las notas del cuaderno seleccionado
                DibujarNotasMenu(idCuaderno);
            };

            _cuadernosRect.Add(botonCuaderno);
            posY += 2; // Incrementa la posición Y para el siguiente botón
        }

        // Añadir el contenido al FrameView
        _cuadernosRect.Add(_cuadernosContentRect);

        // Añadir el FrameView de cuadernos a la ventana principal
        _mainWin.Add(_cuadernosRect);
    }

    private void DibujarNotasMenu(int idCuaderno)
    {
        // Obtener los títulos de las notas del cuaderno seleccionado.
        var titulosNotas = _controlador.ObtenerTitulosNotasCuaderno(idCuaderno);
        int
            posY = 3; // Suponiendo que queremos empezar un poco más abajo en el FrameView para dejar espacio para el título

        _notasRect.Title = $"Notas del Cuaderno {idCuaderno + 1}"; // Ajustar según cómo quieras mostrar el título

        // Limpia el FrameView de notas antes de añadir nuevos botones
        _notasRect.RemoveAll();

        // Añadir botones por cada título de nota
        foreach (var titulo in titulosNotas)
        {
            var botonNota = new Button(titulo)
            {
                X = Pos.At(2), // Posición dentro de notasRect
                Y = Pos.At(posY),
                Height = 1,
            };

            botonNota.Clicked += () =>
            {
                // Lógica al seleccionar una nota
                Console.WriteLine($"Nota {titulo} seleccionada.");
            };

            _notasRect.Add(botonNota);
            posY += 2;
        }

        // Requerido para que la UI se actualice adecuadamente.
        _mainWin.SetNeedsDisplay();
    }
}