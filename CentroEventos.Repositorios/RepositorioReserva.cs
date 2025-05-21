using System.Data;
using Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    readonly string _nombreArchivo = "reservas.txt";

    private int GenerarId()
    {
        return Listar().Count()+1;
    }
    public void Agregar(Reserva reserva)
    {
        reserva.Id = GenerarId();
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(reserva.Id); sw.WriteLine(reserva.PersonaId); sw.WriteLine(reserva.EventoDeportivoId); sw.WriteLine(reserva.FechaAltaReserva); sw.WriteLine(reserva.EstadoAsistencia);
    }

    public void Eliminar(int id)
    {
        var listaTotal = Listar();
        foreach (Reserva r in listaTotal)
        {
            if (r.Id == id)
            {
                r.FechaAltaReserva = DateTime.MaxValue;
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (Reserva r in listaTotal)
        {
            sw.WriteLine(r.Id); sw.WriteLine(r.PersonaId); sw.WriteLine(r.EventoDeportivoId); sw.WriteLine(r.FechaAltaReserva); sw.WriteLine(r.EstadoAsistencia);
        }
    }

    public void Modificar(Reserva reserva)
    {
        var listaTotal = Listar();
        for (int i = 0; i < listaTotal.Count(); i++)
        {
            if (listaTotal[i].Id == reserva.Id)
            {
                listaTotal[i].PersonaId = reserva.PersonaId; listaTotal[i].EventoDeportivoId = reserva.EventoDeportivoId; listaTotal[i].FechaAltaReserva = DateTime.Now;
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (Reserva r in listaTotal)
        {
            sw.WriteLine(r.Id); sw.WriteLine(r.PersonaId); sw.WriteLine(r.EventoDeportivoId); sw.WriteLine(r.FechaAltaReserva); sw.WriteLine(r.EstadoAsistencia);  
        }
    }

    public List<Reserva> Listar()
    {
        var listaTotal = new List<Reserva>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var reserva = new Reserva();
            reserva.Id = int.Parse(sr.ReadLine() ?? ""); reserva.PersonaId = int.Parse(sr.ReadLine() ?? ""); reserva.EventoDeportivoId = int.Parse(sr.ReadLine() ?? ""); reserva.FechaAltaReserva = DateTime.Parse(sr.ReadLine() ?? ""); reserva.EstadoAsistencia = (EstadoAsistencia)Enum.Parse(typeof(EstadoAsistencia), sr.ReadLine() ?? "");
            if (reserva.FechaAltaReserva != DateTime.MaxValue)
            {
                listaTotal.Add(reserva);
            }   
        }

        return listaTotal;
    }

    public Reserva ObtenerPorId(int id)
    {
        var listaTotal = Listar();
        return listaTotal[id];
    }

    public bool ExistePorId(int reservaId)
    {
        var listaTotal = Listar();
        foreach (Reserva r in listaTotal)
        {
            if (r.Id == reservaId)
            {
                return true;
            }
        }
        return false;
    }

    public List<Reserva> ListarEventos(int id)
    {
        var listaTotal = Listar();
        var listaValida = new List<Reserva>();

        foreach (Reserva r in listaTotal)
        {
            if (r.EventoDeportivoId == id && r.FechaAltaReserva != DateTime.MaxValue)
            {
                listaValida.Add(r);
            }
        }

        return listaValida;
    }
}