using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    void Eliminar(int id);
    void Modificar(Usuario usuario);
}
