using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacionProvisorio Auth, ReservaValidador reservaValidador)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        //Verificamos los permisos del usuario
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        //Validamos los datos de la reserva
        if(reservaValidador.Validar(reserva, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);            
        }
        //Buscamos la reserva en el repositorio y si existe la modificamos
        repoReserva.Modificar(reserva);
    }
}
