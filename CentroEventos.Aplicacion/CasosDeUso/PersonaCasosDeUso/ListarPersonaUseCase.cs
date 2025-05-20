using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class ListarPersonaUseCase(IRepositorioPersona repoPersona)
{
    public List<Persona> Ejecutar()
    {
        return repoPersona.Listar();
    }
}
