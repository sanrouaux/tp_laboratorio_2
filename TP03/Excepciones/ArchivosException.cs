using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Crea una instancia de una Excepcion por error en lectura/escritura de archivos
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error de Archivo", innerException)
        {
        }
    }
}
