using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(){}
    public OperacionInvalidaException(string mensaje) : base (mensaje){}
}
