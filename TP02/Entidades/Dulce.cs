using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Crea una instancia del objeto Dulce a partir de los parámetros introducidos
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Código de barras del producto</param>        
        /// <param name="color">Color del empaque del producto</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Porpiedad de sólo lectura. Devuelve la cantidad de calorías de un dulce
        /// Los dulces tienen 80 calorías
        /// </summary>
        /// <returns>Cantidad de calorías de un dulce</returns>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Publica todos los datos del Dulce.
        /// </summary>
        /// <returns>Cadena con el tipo de producto, código de barras, marca, color de empaque y calorías</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
