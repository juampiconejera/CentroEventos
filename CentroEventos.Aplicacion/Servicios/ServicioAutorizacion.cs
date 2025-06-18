using System;
using System.Text.RegularExpressions;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(List<Permiso> permisos, Permiso permiso)
    {
        if (permisos.Contains(permiso))
        {
            return true;
        }
        else return false;
    }
}
