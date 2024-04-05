using System;
using System.Text.RegularExpressions;

namespace Program
{

    class Tui
    {
        private Controlador _controlador;
        private Regex _esC;
        private Regex _esNumero;
        private Regex _esQ;
        private Regex _esM;
        private Regex _esT;

        public Tui(Controlador controlador)
        {
            _controlador = controlador;
            // Expresión regular que valida si un string contiene únicamente c o C
            _esC = new Regex(@"^(c|C)$");
            // Expresión regular que valida si un string contiene únicamente q o Q
            _esQ = new Regex(@"^(q|Q)$");
            // Expresión regular que valida si un string contiene más de un dígito.
            _esNumero = new Regex(@"^\d+$");
            // Expresión regular que valida si un string contiene únicamente m o M
            _esM = new Regex(@"^(m|M)$");
            // Expresión regular que valida si un string contiene únicamente t o T
            _esT = new Regex(@"^(t|T)$");
        }

        public void Run()
        {
            /* Función principal que ejecuta el programa. */
            Bienvenida();


            while (true)
            {
                string opcion = MenuDeOpciones();
                // Se valida si la opción introducida por el usuario es c para crear un cuaderno.
                if (_esC.IsMatch(opcion))
                {
                    CrearCuaderno();
                }
                // Se valida si la opción introducida por el usuario es q para salir del programa.
                else if (_esQ.IsMatch(opcion))
                {
                    Salir();
                }
                // Si no es c ni es q, pero sigue siendo verdadero, es porque es un número.
                else if (_esNumero.IsMatch(opcion))
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
            if (_esC.IsMatch(opcion) || _esQ.IsMatch(opcion) || (_esNumero.IsMatch(opcion) && int.Parse(opcion) <= _controlador.ObtenerTitulosCuaderno().Count) || _esM.IsMatch(opcion) || _esT.IsMatch(opcion))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        private void CrearCuaderno()
        {
            Console.WriteLine("Por favor, introduce el título de tu nuevo cuaderno:");
            string titulo = Console.ReadLine();
            _controlador.CrearCuaderno(titulo);
        }

        private void SeleccionarCuaderno(string opcion)
        {
            try
            {
                int idCuaderno = int.Parse(opcion);
                var cuaderno = _controlador.SeleccionarCuaderno(idCuaderno);
                {
                    while (true)
                    {
                        Console.WriteLine($"Cuaderno: {cuaderno.Titulo}\n\n");
                        Console.WriteLine($"================================================== \n\n");
                        Console.WriteLine($"Este cuaderno se creó el {cuaderno.HoraCreacion}\n");
                        Console.WriteLine($"Este cuaderno se modificó el {cuaderno.HoraModificacion}\n\n");
                        Console.WriteLine($"==================================================  \n\n");
                        Console.WriteLine("Selecciona el id de la nota a ver, o 't' para modificar el título del cuaderno, o 'c' para crear una nueva nota, o 'q' para volver a la selección de cuadernos.");

                        for (int i = 0; i < cuaderno.Notas.Count; i++)
                        {
                            Console.WriteLine($"({i}) {cuaderno.Notas[i].Titulo}");
                        }

                        string opcionNota = Console.ReadLine();

                        if (_esNumero.IsMatch(opcionNota))
                        {
                            MostrarNota(opcionNota, idCuaderno);
                        }
                        else if (_esT.IsMatch(opcionNota))
                        {
                            ModificarTituloCuaderno(idCuaderno);
                        }
                        else if (_esC.IsMatch(opcionNota))
                        {
                            CrearNota(idCuaderno);
                        }
                        else if (_esQ.IsMatch(opcionNota))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No has elegido una opción correcta. Por favor, vuelve a intentarlo.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Algo pasó que no pudimos seleccionar el cuaderno :(");
            }
        }

        private void MostrarNota(string idNota, int idCuaderno)
        {
            try
            {
                int id = int.Parse(idNota);
                var nota = _controlador.SeleccionarNota(idCuaderno, id);
                Console.WriteLine($"{nota.Titulo}\n\n");
                Console.WriteLine($"==================================================  \n\n");
                Console.WriteLine($"Esta nota se creó el {nota.HoraCreacion}\n");
                Console.WriteLine($"Esta nota se modificó el: {nota.HoraModificacion}\n\n");
                Console.WriteLine($"==================================================  \n\n");
                Console.WriteLine($"{nota.Contenido}\n");
                Console.WriteLine("Introduce 'q' para volver al selector de notas, 'm' para modificar el contenido, o 't' para modificar el título.");

                while (true)
                {

                    string opcion = Console.ReadLine();

                    if (_esT.IsMatch(opcion))
                    {
                        ModificarTituloNota(nota);
                        break;
                    }
                    else if (_esM.IsMatch(opcion))
                    {
                        ModificarContenidoNota(nota);
                        break;
                    }
                    else if (_esQ.IsMatch(opcion))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No has elegido una opción correcta. Por favor, vuelve a intentarlo.");
                    }
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Algo pasó que no pudimos seleccionar la nota :(");
            }
        }
        private void CrearNota(int idCuaderno)
        {
            Console.WriteLine("Por favor, introduce el título de tu nueva nota:");
            string titulo = Console.ReadLine();
            _controlador.CrearNota(idCuaderno, titulo, " ");
            Console.WriteLine("");
        }

        private void ModificarTituloNota(Nota nota)
        {
            Console.WriteLine("Por favor, introduce el nuevo título:");
            nota.Titulo = Console.ReadLine();
            Console.WriteLine("");
        }

        private void ModificarTituloCuaderno(int idCuaderno)
        {
            Console.WriteLine("Por favor, introduce el nuevo título:");
            string nuevoTitulo = Console.ReadLine();
            _controlador.ModificarTituloCuaderno(idCuaderno, nuevoTitulo);
            Console.WriteLine($"El título del cuaderno ha sido cambiado a: {nuevoTitulo}");
            Console.WriteLine("");
        }

        private void ModificarContenidoNota(Nota nota)
        {
            Console.WriteLine($"Escribe el nuevo contenido para {nota.Titulo}:");

            string nuevoContenido = Console.ReadLine();

            nota.Contenido = nuevoContenido;
            Console.WriteLine("");
        }

        private void Salir()
        {
            _controlador.UsuarioActual.GuardarSesión();
            Environment.Exit(0);
        }
    }
}