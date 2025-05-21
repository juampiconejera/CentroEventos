using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo)
{
    public List<EventoDeportivo> Ejecutar()
    {   
        return repoEventoDeportivo.ListarEventosDisponibles();
    }
}