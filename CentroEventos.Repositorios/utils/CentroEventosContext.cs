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

    //add journalMode
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