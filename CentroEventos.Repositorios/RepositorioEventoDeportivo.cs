using System;
using System.Data;
using System.Diagnostics.Tracing;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;

    public RepositorioEventoDeportivo(IRepositorioReserva repoReserva, IRepositorioPersona repoPersona)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
    }
    public void Agregar(EventoDeportivo eventoDeportivo)
    {
        using (var context = new CentroEventosContext())
        {
            context.Add(eventoDeportivo);
            context.SaveChanges();
        }
    }

    public void Modificar(EventoDeportivo eventoModif)
    {
        using (var context = new CentroEventosContext())
        {
            EventoDeportivo? eventoDeportivo = context.EventosDeportivos.FirstOrDefault(e => e.Id == eventoModif.Id);
            if (eventoDeportivo != null)
            {
                eventoDeportivo.Nombre = eventoModif.Nombre;
                eventoDeportivo.Descripcion = eventoModif.Descripcion;
                eventoDeportivo.FechaHoraInicio = eventoModif.FechaHoraInicio;
                eventoDeportivo.DuracionHoras = eventoModif.DuracionHoras;
                eventoDeportivo.CupoMaximo = eventoModif.CupoMaximo;
                eventoDeportivo.ResponsableId = eventoModif.ResponsableId;
                context.SaveChanges();
            }
        }
    }

    public void Eliminar(int idEvento)
    {
        using (var context = new CentroEventosContext())
        {
            EventoDeportivo? eventoDeportivo = context.EventosDeportivos.FirstOrDefault(e => e.Id == idEvento);
            if (eventoDeportivo != null)
            {
                context.Remove(eventoDeportivo);
                context.SaveChanges();
            }
        }
    }

    public EventoDeportivo ObtenerPorId(int idEvento)      //REVISAR LOGICA
    {
        using (var context = new CentroEventosContext())
        {
            EventoDeportivo? eventoDeportivo = context.EventosDeportivos.FirstOrDefault(e => e.Id == idEvento)!;
            return eventoDeportivo;
        }
    }

    public bool ExistePorId(int idEvento)
    {
        using (var context = new CentroEventosContext())
        {
            EventoDeportivo? evento = context.EventosDeportivos.FirstOrDefault(e => e.Id == idEvento);
            return evento != null;
        }
    }

    public List<EventoDeportivo> Listar()
    {
        using (var context = new CentroEventosContext())
        {
            return context.EventosDeportivos.ToList();
        }
    }

    public List<Persona> ListarPresentes(int idEvento)
    {
        List<Persona> listaRetorno = new List<Persona>();
        using (var context = new CentroEventosContext())
        {
            List<Reserva> listaReservas = _repoReserva.ListarReservasPorEvento(idEvento);   //obtengo la lista de reservas de el evento determinado
            foreach (Reserva r in listaReservas)
            {
                if (r.EstadoAsistencia == EstadoAsistencia.Presente)
                {
                    if (_repoPersona.ExistePorId(r.PersonaId))  //primero chequeo que exista
                    { 
                        Persona persona = _repoPersona.ObtenerPorId(r.PersonaId);   //lo busco
                        listaRetorno.Add(persona);      //lo agrego
                    }
                }
            }
            return listaRetorno;
        }
    }
    
    public List<EventoDeportivo> ListarEventosDisponibles()
    {
        List<EventoDeportivo> listaRetorno = new List<EventoDeportivo>();
        using (var context = new CentroEventosContext())
        {
            List<EventoDeportivo> listaTotal = context.EventosDeportivos.ToList();
            foreach (EventoDeportivo e in listaTotal)
            {
                List<Reserva> listaReservas = _repoReserva.ListarReservasPorEvento(e.Id);
                if (e.Nombre != "ELIMINADO" && e.CupoMaximo > listaReservas.Count())   //si el cupo maximo es mayor a la cantidad de reservas, hay lugar disponible
                {
                    listaRetorno.Add(e);    //agrego el evento deportivo a la lista
                }
            }
        }
        return listaRetorno;    //devuelvo la lista con eventos disponibles
    }
}