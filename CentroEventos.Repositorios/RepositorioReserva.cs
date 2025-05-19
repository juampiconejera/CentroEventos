using System.Data;
using Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    readonly string _nombreArchivo = "Reservas.txt";

    private int GenerarId()
    {
        return Listar().Count();
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
                r.PersonaId = int.MaxValue; r.EventoDeportivoId = int.MaxValue;
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
        int i;
        for (i = 0; i < listaTotal.Count(); i++)
        {
            if (listaTotal[i].PersonaId == reserva.PersonaId)
            {
                listaTotal[i].PersonaId = reserva.PersonaId; listaTotal[i].EventoDeportivoId = reserva.EventoDeportivoId; listaTotal[i].FechaAltaReserva = reserva.FechaAltaReserva; listaTotal[i].EstadoAsistencia = reserva.EstadoAsistencia;
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        for (int j = 0; j < i; j++)
        {
            sw.WriteLine(listaTotal[j].Id); sw.WriteLine(listaTotal[j].PersonaId); sw.WriteLine(listaTotal[j].EventoDeportivoId); sw.WriteLine(listaTotal[j].FechaAltaReserva); sw.WriteLine(reserva.EstadoAsistencia);
        }
    }

    public List<Reserva> Listar()
    {
        var listaTotal = new List<Reserva>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var reserva = new Reserva();
            reserva.Id = int.Parse(sr.ReadLine()); reserva.PersonaId = int.Parse(sr.ReadLine()); reserva.EventoDeportivoId = int.Parse(sr.ReadLine()); reserva.FechaAltaReserva = DateTime.Parse(sr.ReadLine()); reserva.EstadoAsistencia = (EstadoAsistencia)Enum.Parse(typeof(EstadoAsistencia), sr.ReadLine());
            listaTotal.Add(reserva);
        }

        return listaTotal;
    }

    public Reserva ObtenerPorId(int id)
    {
        var listaTotal = Listar();
        return listaTotal[id];
    }

    public List<Reserva> ListarEventos(int id)
    {
        var listaTotal = Listar();
        var listaValida = new List<Reserva>();

        foreach (Reserva r in listaTotal)
        {
            if (r.Id == id)
            {
                listaValida.Add(r);
            }
        }

        return listaValida;
    }
}