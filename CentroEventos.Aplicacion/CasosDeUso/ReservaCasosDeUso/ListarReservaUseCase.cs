using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ListarReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int idUsuario)
    {
        //Validamos los permisos
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        //Listamos las reservas
        repoReserva.Listar();
    }
}
