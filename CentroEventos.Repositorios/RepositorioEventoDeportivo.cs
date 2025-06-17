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

    public EventoDeportivo? ObtenerPorId(int idEvento)      //REVISAR LOGICA
    {
        using (var context = new CentroEventosContext())
        {
            EventoDeportivo? eventoDeportivo = context.EventosDeportivos.FirstOrDefault(e => e.Id == idEvento);
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

        var evento = ObtenerPorId(idEvento);

        var listaReservas = _repoReserva.Listar();

        foreach (Reserva r in listaReservas)
        {
            if (r.EventoDeportivoId == idEvento && r.EstadoAsistencia == EstadoAsistencia.Presente)
            {
                foreach (Persona p in listaPersonas)
                {
                    if (p.Id == r.PersonaId)
                    {
                        Persona personaAdd = p;
                        listaRetorno.Add(personaAdd);
                        break;
                        //lo agrego a la lista y paso con el siguiente
                    }
                }
            }
        }
        return listaRetorno;
    }

    public List<EventoDeportivo> ListarEventosDisponibles()
    {
        List<EventoDeportivo> listaRetorno = new List<EventoDeportivo>();
        var listaTotal = Listar();

        foreach (EventoDeportivo e in listaTotal)
        {
            var listaReservas = _repoReserva.ListarReservasPorEvento(e.Id);

            if (e.Nombre != "ELIMINADO" && e.CupoMaximo > listaReservas.Count())   //si el cupo maximo es mayor a la cantidad de reservas, hay lugar disponible
            {
                listaRetorno.Add(e);    //agrego el evento deportivo a la lista
            }
        }

        return listaRetorno;    //devuelvo la lista con eventos disponibles
    }
}