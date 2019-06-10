using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda información de texto en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta donde se creará el archivo</param>
        /// <param name="datos">Información a guardar</param>
        /// <returns>True si logra guardar; ArchivosException si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter escritura = new StreamWriter(archivo);
                foreach(char c in datos)
                {
                    if(c == '\n')
                    {
                        escritura.WriteLine();
                    }
                    else
                    {
                        escritura.Write(c);
                    }
                }                            
                escritura.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }            
        }

        /// <summary>
        /// Metodo que lee información desde un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta al archivo</param>
        /// <param name="datos">Información de texto a leer</param>
        /// <returns>True si logra leer y cadena con la información en una variable de salida; ArchivosException si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            try
            {
                string aux;
                StreamReader lectura = new StreamReader(archivo);
                while ((aux = lectura.ReadLine()) != null)
                {
                    datos += aux + "\n";
                }                
                lectura.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
