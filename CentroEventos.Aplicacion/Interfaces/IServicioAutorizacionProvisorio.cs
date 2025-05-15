using System;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacionProvisorio
{
    bool PoseeElPermiso(int IdUsuario);
}
