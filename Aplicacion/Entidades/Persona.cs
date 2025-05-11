using System;

namespace Aplicacion.Entidades;
//Se van a usar validaciones , asi que no usamos propiedades auto implementadas.
public class Persona
{
private int _id;//único, debe ser autoincremental gestionado por el repositorio
private string? _dni;//único
private string? _nombre;
private string? _apellido;
private string? _email;// único
private string? _telefono;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string? Dni
        {
            get => _dni;
            set => _dni = value;
        }

        public string? Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string? Apellido
        {
            get => _apellido;
            set => _apellido = value;
        }

        public string? Email
        {
            get => _email;
            set => _email = value;
        }

        public string? Telefono
        {
            get => _telefono;
            set => _telefono = value;
        }
    }


