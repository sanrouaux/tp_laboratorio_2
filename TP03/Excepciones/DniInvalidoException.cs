using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI Inválido";

        /// <summary>
        /// Crea una instancia de una Excepcion por DNI Inválido
        /// </summary>
        public DniInvalidoException() : base(mensajeBase)
        {
        }

        /// <summary>
        /// Crea una instancia de una Excepcion por DNI Inválido
        /// </summary>
        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {            
        }

        /// <summary>
        /// Crea una instancia de una Excepcion por DNI Inválido
        /// </summary>
        public DniInvalidoException(string message) : base(mensajeBase + "\n" + message)
        {            
        }

        /// <summary>
        /// Crea una instancia de una Excepcion por DNI Inválido
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base(mensajeBase + "\n" + message, e)
        {            
        }
    }
}
