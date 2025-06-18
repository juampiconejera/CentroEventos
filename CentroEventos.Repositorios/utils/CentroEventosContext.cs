using System;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }                        //determinamos nombres de las tablas de la db
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroDeportivo.sqlite");
    }

    public void ConfigureSqliteJournalMode()
    {
        this.Database.EnsureCreated();
        var connection = this.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
        }
    }
}

/*protected override void OnConfiguring(...):
Es un método de la clase DbContext de Entity Framework Core que puedes sobrescribir para configurar cómo se conecta tu contexto a la base de datos.

optionsBuilder.UseSqlite("data source=CentroDeportivo.sqlite");:
Le dice a EF Core que use SQLite como base de datos y que el archivo de la base de datos se llamará CentroDeportivo.sqlite (se creará en la carpeta del proyecto si no existe).

En resumen:
Estas líneas configuran tu contexto para que use una base de datos SQLite local llamada CentroDeportivo.sqlite.*/