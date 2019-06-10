using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,
            Descremada
        }

        private ETipo tipo;

        /// <summary>
        /// Crea una instancia del objeto Leche a partir de los tres parámetros introducidos. Inicializa TIPO por defecto 
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Código de barras del producto</param>        
        /// <param name="color">Color del empaque del producto</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : this(marca, codigo, color, ETipo.Entera)
        {            
        }

        /// <summary>
        /// Crea una instancia del objeto Leche a partir de los cuatro parámetros introducidos.
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Código de barras del producto</param>        
        /// <param name="color">Color del empaque del producto</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Porpiedad de sólo lectura. Devuelve la cantidad de calorías de una leche
        /// Las leches tienen 20 calorías
        /// </summary>
        /// <returns>Cantidad de calorías de una leche</returns>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Publica todos los datos de la Leche.
        /// </summary>
        /// <returns>Cadena con el tipo de producto, código de barras, marca, color de empaque, calorías y tipo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
