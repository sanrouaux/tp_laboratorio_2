using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Guardar una cadena de texto en un archivo de texto en el escritorio de la máquina
        /// </summary>
        /// <param name="texto">Texto que será guardado</param>
        /// <param name="archivo">Nombre del archivo de texto</param>
        /// <returns>True si logra escribir archivo de texto; False si se lanzan excepciones</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno;
            try
            {
                using (StreamWriter sr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                        + "\\" + archivo, true))
                {
                    sr.WriteLine(texto);                   
                    retorno = true;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;  
        }
    }
}
