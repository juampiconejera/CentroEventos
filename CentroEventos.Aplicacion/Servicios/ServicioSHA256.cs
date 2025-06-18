using System;
using CentroEventos.Aplicacion.Interfaces;
using System.Security.Cryptography; 
using System.Text;
//para usar sha256
//sha256 trabaja con bytes, por lo tanto debemos utilizarla

namespace CentroEventos.Aplicacion.Servicios;

public class ServicioSHA256 : IServicioSHA26
{
    public string getSha256(string entrada)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            //encoding viene de System.Text
            //convertimos la entrada en un array de bytes
            byte[] bytes = Encoding.UTF8.GetBytes(entrada);
            // calculamos el hash SHA-256
            byte[] hashBytes = sha256.ComputeHash(bytes);

            //convertimos a hexadecimal
            StringBuilder builder = new StringBuilder();
            foreach (var b in hashBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
