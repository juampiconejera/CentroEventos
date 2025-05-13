using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException(){}
    public EntidadNotFoundException(string mensaje) : base (mensaje) {}
}
