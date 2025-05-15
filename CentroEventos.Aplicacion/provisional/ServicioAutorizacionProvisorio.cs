using System;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.provisional;

public class ServicioAutorizacionProvisorio : IServicioAutorizacionProvisorio
{
    public bool PoseeElPermiso(int IdUsuario)
    {
        if(IdUsuario == 1){
            return true;
        }
        return false;
    }
}
