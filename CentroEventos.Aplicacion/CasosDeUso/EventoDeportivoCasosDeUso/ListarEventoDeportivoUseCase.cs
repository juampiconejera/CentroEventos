using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int idUsuario)
    {
        //Validamos los permisos
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }

        repoEventoDeportivo.Listar();
    }
}