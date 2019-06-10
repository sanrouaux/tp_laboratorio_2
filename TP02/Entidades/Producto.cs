using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Crea una instancia del objeto a partir de los parámetros introducidos
        /// </summary>
        /// <param name="codigo">Código de barras del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color del empaque del producto</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorías del producto
        /// </summary>
        /// <returns>Cantidad de calorías del producto</returns>
        protected abstract short CantidadCalorias
        {
            get;
        }
        
        /// <summary>
        /// Convierte un objeto Producto en una cadena con los datos de su código de barras, marca y color de empaque
        /// </summary>
        /// <param name="p">Producto a ser convertido explícitamente</param>
        /// <returns>Cadena con los datos del código de barras, marca y color de empaque de un producto</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p.codigoDeBarras);
            sb.AppendLine("MARCA          : " + p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Cadena con los datos de código de barras, marca y color de empaque de un producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Compara dos productos. Dos productos serán iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Primer producto a comparar</param>
        /// <param name="v2">Segundo producto a comparar</param>
        /// <returns>True si los productos tiene el mismo código de barras; en caso contrario, false</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Primer producto a comparar</param>
        /// <param name="v2">Segundo producto a comparar</param>
        /// <returns>False si los productos tiene el mismo código de barras; caso contrario, true</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
