using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Permite obtener datos de uno o varios paquetes
        /// </summary>
        /// <param name="elemento">Paquete, o Correo del cual se buscarán los paquetes</param>
        /// <returns>Cadena con los datos del/de los paquete/s</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
