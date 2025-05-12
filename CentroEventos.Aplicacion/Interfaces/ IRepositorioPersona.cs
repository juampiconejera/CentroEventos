namespace CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    void Eliminar(Persona persona);
    void Modificar(Persona persona);
    Persona? ObtenerPorId(int id);
    List<Persona> Listar();
}