using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda información de objetos en un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta donde se creará el archivo</param>
        /// <param name="datos">Información del objeto a guardar</param>
        /// <returns>True si logra guardar; ArchivosException si no</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                StreamWriter escritor = new StreamWriter(archivo);
                serializador.Serialize(escritor, datos);                
                escritor.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Metodo que lee información de objetos desde un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta al archivo</param>
        /// <param name="datos">Información de objetos a leer</param>
        /// <returns>True si logra leer y información de objetos en una variable de salida; ArchivosException si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            Object salida = new Object();
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                StreamReader lector = new StreamReader(archivo);                
                salida = serializador.Deserialize(lector);
                datos = (T)salida;
                lector.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
