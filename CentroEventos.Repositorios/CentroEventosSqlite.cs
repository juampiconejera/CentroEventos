using System;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        if(context.Database.EnsureCreated())
        { 
            Console.WriteLine("Se creó base de datos");
        }
    }
}
