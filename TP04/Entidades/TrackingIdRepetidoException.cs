using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Crea una instancia de la excepción de TrackingID repetido
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {            
        }

        /// <summary>
        /// Crea una instancia de la excepción de TrackingID repetido
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="inner">Excepción previa que llevó a lanzar la actual excepción</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
