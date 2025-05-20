public class MetodosComunes
{
    int leerId(string tipo)
    {
        Console.WriteLine($"Ingrese el {tipo} Id: ");
        return int.Parse(Console.ReadLine() ?? "");
    }
}