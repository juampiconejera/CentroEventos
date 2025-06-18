using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int id { get; set; }
    private string? _nombre;
    private string? _apellido;
    private string? _email;
    private string? _password;
    private List<Permiso>? _permisos;

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
    public string Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string Apellido
    {
        get => _apellido;
        set => _apellido = value;
    }

    public string Email
    {
        get => _email;
        set => _email = value;
    }

    public string Password
    {
        get => _password;           //el hash del password lo realizo en el caso de uso
        set => _password = value;
    }

    public List<Permiso> Permisos
    {
        get => _permisos;
        set => _permisos = value;
    }
}
