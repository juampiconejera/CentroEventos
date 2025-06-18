using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    // Propiedades autoimplementadas
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Permiso>? Permisos { get; private set; }

    public Usuario()
    {

    }

    public Usuario(string nombre, string apellido, string email, string password, List<Permiso> permisos)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
        Permisos = permisos;
    }
}
