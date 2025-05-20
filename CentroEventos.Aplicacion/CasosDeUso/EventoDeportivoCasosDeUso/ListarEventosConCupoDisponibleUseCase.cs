using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo)
{
    public void Ejecutar(int idUsuario)
    {   
        repoEventoDeportivo.ListarEventosDisponibles();
    }
}