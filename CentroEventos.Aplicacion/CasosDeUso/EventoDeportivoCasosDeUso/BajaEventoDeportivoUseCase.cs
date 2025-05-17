using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class BajaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        
        repoEventoDeportivo.Eliminar(eventoDeportivo.Id);
    }
}
