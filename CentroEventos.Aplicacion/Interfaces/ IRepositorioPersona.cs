namespace CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    void Eliminar(Persona persona);
    void Modificar(Persona persona);
    bool ExistePorId(int id);
    bool ExistePorDni(string dni);
    bool ExistePorEmail(string dni);
    List<Persona> Listar();
}