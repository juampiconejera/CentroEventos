public class MetodosComunes
{
    public int leerId(string tipo)
    {
        Console.WriteLine($"Ingrese el {tipo} Id: ");
        return int.Parse(Console.ReadLine() ?? "");
    }

    public void MostrarMenuConCuadro(string titulo, string[] opciones)
    {
        int ancho = opciones.Max(op => op.Length) + 4;
        string bordeSuperior = "┌" + new string('─', ancho) + "┐";
        string bordeInferior = "└" + new string('─', ancho) + "┘";
        string separador = "├" + new string('─', ancho) + "┤";

        Console.WriteLine(bordeSuperior);
        Console.WriteLine("|" + centrarTexto(titulo, ancho) + "|");
        Console.WriteLine(separador);
        foreach (var op in opciones)
        {
            Console.WriteLine("| " + op.PadRight(ancho - 2) + " |");
        }
        Console.WriteLine(bordeInferior);
        Console.Write("Seleccione una opción: ");
    }
    private string centrarTexto(string text, int width)
    {
        int padding = (width - text.Length) / 2;
        return new string( ' ', padding) + text + new string(' ', width - text.Length - padding);
    }
}