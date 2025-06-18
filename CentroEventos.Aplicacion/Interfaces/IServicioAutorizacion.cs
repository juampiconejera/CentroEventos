using System;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(List<Permiso> permisos, Permiso permiso);
}
