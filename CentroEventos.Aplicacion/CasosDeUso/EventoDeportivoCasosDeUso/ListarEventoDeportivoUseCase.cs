using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo)
{
    public void Ejecutar()
    {
        repoEventoDeportivo.Listar();
    }
}