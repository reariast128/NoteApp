using Gtk;
namespace NoteApp;

public class Gui
{
    static void callback(object obj, EventArgs args)
    {
        Button mybutton = (Button)obj;
        Console.WriteLine("Hello again - {0} was pressed", (string)mybutton.Label);
    }

    static void exit_event(object obj, EventArgs args)
    {
        Application.Quit();
    }

    public static void Main(string[] args)
    {
        Usuario usuario = new Usuario("Yo");
        Controlador controlador = new Controlador(usuario);
        Application.Init();

        /* Create a new window */
        Window window = new Window("NoteApp");
        window.Resize(1220, 720);

        /* Set a handler for delete_event that immediately exits GTK */
        window.DeleteEvent += (o, e) => Application.Quit();

        /* Sets the border width of the window */
        window.BorderWidth = 20;

        /* Create three 2x2 tables */
        Table table1 = new Table(2, 2, true);
        Table table2 = new Table(2, 2, true);
        Table table3 = new Table(2, 2, true);

        /* Create a ComboBox for the notebooks */
        ComboBox comboBox = new ComboBox();
        ListStore cuadernos = new ListStore(typeof(string));
        comboBox.Model = cuadernos;
        table1.Attach(comboBox, 1, 2, 0, 1);

        /* Create buttons */
        Button button1 = new Button("Cuaderno");
        button1.SetSizeRequest(400, 400);
        button1.Clicked += (sender, e) => {
            
            foreach (string cuaderno in controlador.ObtenerTitulosCuaderno())
            {
                cuadernos.AppendValues(cuaderno);
            }

            // Show the ComboBox
            comboBox.Show();
        };
        table1.Attach(button1, 0, 1, 0, 1);
        button1.Show();

        /* Create "Quit" button */
        Button quitButton = new Button("Quit");
        quitButton.Clicked += exit_event;
        quitButton.Show();

        /* Put the tables in a horizontal box */
        HBox hbox = new HBox(false, 10);
        hbox.PackStart(table1, true, true, 0);
        hbox.PackStart(table2, true, true, 0);
        hbox.PackStart(table3, true, true, 0);

        /* Put the horizontal box and the Quit button in a vertical box */
        VBox vbox = new VBox(false, 10);
        vbox.PackStart(hbox, true, true, 0);
        vbox.PackStart(quitButton, false, false, 0);

        /* Add the vertical box to the window */
        window.Add(vbox);

        /* Show all elements */
        window.ShowAll();

        Application.Run();
    }
}