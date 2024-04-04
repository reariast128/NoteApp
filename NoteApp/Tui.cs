using Terminal.Gui;

namespace NoteApp;

class Tui
{
    private ColorScheme _appColorScheme;

    private Window _mainWin;

    public Tui()
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
    }

    public void Run()
    {
        Application.Init();
        var top = Application.Top;
        
        Application.Top.ColorScheme = _appColorScheme;

        // Crea la ventana principal

        top.Add(_mainWin);

        // Dimensiones compartidas para los rectángulos
        int rectWidth = 20;
        int rectHeight = 10;
        int spacing = 2;
        
        DibujarRectangulosMenu(rectWidth, rectHeight, spacing);

        Application.Run();
    }

    private void DibujarRectangulosMenu(int ancho, int alto, int espaciado)
    {
        // Crea tres rectángulos (Views) cada uno con un Label en su parte superior.
        for (int i = 0; i < 3; i++)
        {
            var rect = new View()
            {
                X = Pos.Percent(10 + i * (ancho + espaciado)), // Posiciona horizontalmente
                Y = Pos.Percent(20), // Posiciona verticalmente
                Width = ancho,
                Height = alto,
                ColorScheme = _appColorScheme, // Asegura que el rectángulo use el esquema de colores global
            };

            var label = new Label($"Rect {i + 1}")
            {
                X = Pos.Center(), // Centrar respecto al rectángulo
                Y = Pos.Percent(0), // En la parte superior dentro del rectángulo
                Width = ancho,
                Height = 1,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = _appColorScheme, // Asegura que el label use el esquema de colores global
            };

            rect.Add(label);
            _mainWin.Add(rect);
        }
    }
}