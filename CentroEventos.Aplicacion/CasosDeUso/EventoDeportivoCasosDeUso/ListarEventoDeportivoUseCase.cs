using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class ListarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repoEventoDeportivo.Listar();
    }
}