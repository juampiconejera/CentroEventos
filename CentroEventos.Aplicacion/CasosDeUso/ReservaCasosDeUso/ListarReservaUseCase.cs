using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ListarReservaUseCase(IRepositorioReserva repoReserva)
{
    public void Ejecutar(int idUsuario)
    {
        repoReserva.Listar();
    }
}
