using System;

namespace CentroEventos.Repositorios;

public class CentroDeportivoSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroDeportivoContext();
        if(context.Database.EnsureCreated())
        { 
            Console.WriteLine("Se creó base de datos");
        }
    }
}
