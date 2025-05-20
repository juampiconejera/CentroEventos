using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class ListarPersonaUseCase(IRepositorioPersona repoPersona)
{
    public void Ejecutar()
    {
        repoPersona.Listar();
    }
}
