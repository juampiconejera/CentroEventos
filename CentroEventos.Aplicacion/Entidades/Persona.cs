namespace CentroEventos.Aplicacion.Entidades;

using System;
using CentroEventos.Aplicacion.Interfaces;


public class Persona
{
    // Propiedades autoimplementadas
    public int Id { get; set; }
    public string Dni { get; set; } = string.Empty;         // único
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;       // único
    public string Telefono { get; set; } = string.Empty;

    // Constructor por defecto 
    public Persona() { }

    // Constructor para crear una persona rápidamente
    public Persona(string dni, string nombre, string apellido, string email, string telefono)
    {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    public override string ToString()
    {
        return $"Id: {Id}, DNI: {Dni}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}";
    }
}