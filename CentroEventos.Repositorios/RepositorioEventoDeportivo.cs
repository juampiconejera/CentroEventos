using System;
using System.Data;
using System.Diagnostics.Tracing;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Aplicacion;                               //para verificar EstadoAsistencia, a revisar

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
    readonly string _nombreArchivo = "eventos.txt";
    private int GenerarId()
    {
        return 1;
    }
    public void Agregar(EventoDeportivo eventoDeportivo)
    {
        eventoDeportivo.Id = GenerarId();
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(eventoDeportivo.Id);
        sw.WriteLine(eventoDeportivo.Nombre);
        sw.WriteLine(eventoDeportivo.Descripcion);
        sw.WriteLine(eventoDeportivo.FechaHoraInicio);
        sw.WriteLine(eventoDeportivo.DuracionHoras);
        sw.WriteLine(eventoDeportivo.CupoMaximo);
        sw.WriteLine(eventoDeportivo.ResponsableId);
    }

    public void Modificar(EventoDeportivo eventoModif)
    {
        var listaTotal = Listar();
        for (int i = 0; i < listaTotal.Count; i++)
        {
            if (listaTotal[i].Id == eventoModif.Id)
            {
                listaTotal[i] = eventoModif;
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (EventoDeportivo e in listaTotal)
        {
            sw.WriteLine(e.Id); sw.WriteLine(e.Nombre); sw.WriteLine(e.Descripcion); sw.WriteLine(e.FechaHoraInicio); sw.WriteLine(e.DuracionHoras); sw.WriteLine(e.CupoMaximo); sw.WriteLine(e.ResponsableId);
        }
    }

    public void Eliminar(int idEvento)
    {
        var listaTotal = Listar();  //como lo elimino? buena pregunta dorothy, rocket y vuelvo

    }

    public EventoDeportivo ObtenerPorId(int idEvento)
    {
        var listaTotal = Listar();
        EventoDeportivo eventoRetorno = new EventoDeportivo();
        foreach (EventoDeportivo e in listaTotal)
        {
            if (e.Id == idEvento)
            {
                eventoRetorno = e;
                break;
            }
        }
        return eventoRetorno;
    }

    public bool ExistePorId(int idEvento)
    {
        var listaTotal = Listar();
        foreach (EventoDeportivo e in listaTotal)
        {
            if (e.Id == idEvento)
            {
                return true;
            }
        }
        return false;
    }

    public List<EventoDeportivo> Listar()
    {
        var listaTotal = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.Id = int.Parse(sr.ReadLine() ?? ""); evento.Nombre = sr.ReadLine(); evento.Descripcion = sr.ReadLine(); evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine()); evento.DuracionHoras = double.Parse(sr.ReadLine()); evento.CupoMaximo = int.Parse(sr.ReadLine()); evento.ResponsableId = int.Parse(sr.ReadLine());
            listaTotal.Add(evento);
        }

        return listaTotal;
    }

    public List<Persona> ListarPresentes(int idEvento)
    {
        List<Persona> listaRetorno = new List<Persona>();

        var listaReservas = _repoReserva.Listar();
        var listaPersonas = _repoPersona.Listar();

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
        
        return listaRetorno;
    }
}