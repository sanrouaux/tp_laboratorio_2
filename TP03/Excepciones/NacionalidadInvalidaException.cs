using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Crea una instancia de una Excepcion por Nacionalidad Inválida
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el número de DNI")
        {
        }

        /// <summary>
        /// Crea una instancia de una Excepcion por Nacionalidad Inválida
        /// </summary>
        public NacionalidadInvalidaException(string message) : base("La nacionalidad no se condice con el número de DNI\n" + message)
        {
        }
    }
}
