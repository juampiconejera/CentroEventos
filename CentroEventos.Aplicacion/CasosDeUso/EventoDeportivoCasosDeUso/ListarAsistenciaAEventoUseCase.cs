using System;
using System.Net.Cache;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento)
{
    public List<Persona> Ejecutar(int idEvento)
    {
        //Verificar existencia del evento
        if (!repoEvento.ExistePorId(idEvento))
        {
            throw new EntidadNotFoundException("El Id del evento no corresponde a un evento registrado.");
        }

        //Verificamos si el evento ya pasó
        if (repoEvento.ObtenerPorId(idEvento).FechaHoraInicio > DateTime.Now)
        {
            throw new ValidacionException("El evento deportivo no se ha realizado.");
        }

        return repoEvento.ListarPresentes(idEvento);
    }
}
