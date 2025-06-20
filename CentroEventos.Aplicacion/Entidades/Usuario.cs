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
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    public Usuario(){}
    public Usuario(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public Usuario(string nombre, string apellido, string email, string password)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
    }
    public Usuario(int id, string nombre, string apellido, string email, string password)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
    }
}
