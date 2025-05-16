using System;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Provisional;

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
