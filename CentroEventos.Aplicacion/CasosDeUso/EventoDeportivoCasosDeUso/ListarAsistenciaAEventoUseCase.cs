using System;
using System.Net.Cache;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{
    public void Ejecutar(int idEvento)
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

        repoEvento.ListarPresentes(idEvento);
    }
}
