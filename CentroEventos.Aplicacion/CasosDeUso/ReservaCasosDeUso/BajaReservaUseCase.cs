using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class BajaReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int reservaId, int idUsuario)
    {
        //Verificamos permisos
        if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        
        repoReserva.Eliminar(reservaId);
    }
}
