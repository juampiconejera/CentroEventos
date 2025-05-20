using CentroEventos.Aplicacion.Interfaces;


namespace CentroEventos.Repositorios;

public class ServicioAutorizacionProvisiorio : IServicioAutorizacionProvisorio
{
    public bool PoseeElPermiso(int idUsuario)
    {
        return idUsuario == 1;
    }
}
