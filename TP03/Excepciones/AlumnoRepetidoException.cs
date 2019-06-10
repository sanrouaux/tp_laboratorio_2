using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Crea una instancia de una Excepcion de tipo AlumnoRepetido
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido")
        {

        }
    }
}
