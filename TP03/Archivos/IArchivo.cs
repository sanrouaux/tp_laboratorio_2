using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Método a implementar que guardará información en archivo
        /// </summary>
        /// <param name="archivo">Ruta donde se creará el archivo</param>
        /// <param name="datos">Información a guardar</param>
        /// <returns>True si logra guardar; ArchivosException si no</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Método a implementar que leerá información desde archivo
        /// </summary>
        /// <param name="archivo">Ruta al archivo</param>
        /// <param name="datos">Información a leer</param>
        /// <returns>True si logra leer; ArchivosException si no</returns>
        bool Leer(string archivo, out T datos);
    }
}
