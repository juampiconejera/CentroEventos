using System.Data;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{

     public void Agregar(Reserva reserva)
    {
        using var context = new CentroEventosContext();
        context.Reservas.Add(reserva);
        context.SaveChanges();
    }

     public void Eliminar(int id)
    {
        using var context = new CentroEventosContext();
        var reserva = context.Reservas.FirstOrDefault(r => r.Id == id);
        if (reserva != null)
        {
            reserva.FechaAltaReserva = DateTime.MaxValue;
            context.SaveChanges();
        }
    }

   public void Modificar(Reserva reservaNueva)
    {
        using var context = new CentroEventosContext();
        var reservaExistente = context.Reservas.FirstOrDefault(r => r.Id == reservaNueva.Id);
        if (reservaExistente != null)
        {
            reservaExistente.PersonaId = reservaNueva.PersonaId;
            reservaExistente.EventoDeportivoId = reservaNueva.EventoDeportivoId;
            reservaExistente.FechaAltaReserva = reservaNueva.FechaAltaReserva;
            reservaExistente.EstadoAsistencia = reservaNueva.EstadoAsistencia;
            context.SaveChanges();
        }
    }

    public List<Reserva> Listar()
    {
        using var context = new CentroEventosContext();
        return context.Reservas
                      .Where(r => r.FechaAltaReserva != DateTime.MaxValue)
                      .ToList();
    }

    public Reserva? ObtenerPorId(int id)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.FirstOrDefault(r => r.Id == id);
    }

    public bool ExistePorId(int reservaId)
    {
        using var context = new CentroEventosContext();
        return context.Reservas.Any(r => r.Id == reservaId);
    }

    //"El método ListarEventos de RepositorioReserva no tiene un nombre descriptivo."CORREGIDO
    public List<Reserva> ListarReservasPorEvento(int eventoId)
    {
        using var context = new CentroEventosContext();
        return context.Reservas
                      .Where(r => r.EventoDeportivoId == eventoId && r.FechaAltaReserva != DateTime.MaxValue)
                      .ToList();
    }
}