using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int idUsuario)
    {
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        
        repoEventoDeportivo.ListarEventosDisponibles();
    }
}