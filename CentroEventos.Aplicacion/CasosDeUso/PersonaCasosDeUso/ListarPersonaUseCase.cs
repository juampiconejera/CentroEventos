using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class ListarPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int idUsuario)
    {
        //Verificamos los permisos
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        //Listamos
        repoPersona.Listar();
    }
}
