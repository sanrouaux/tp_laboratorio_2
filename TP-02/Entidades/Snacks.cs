using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Crea una instancia del objeto Snacks a partir de los parámetros introducidos
        /// </summary>
        /// <param name="marca">Marca del Snack</param>
        /// <param name="codigo">Código de barras</param>        
        /// <param name="color">Color del empaque</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Porpiedad de sólo lectura. Retorna la cantidad de calorías de un snack
        /// El snack tienen 104 calorías
        /// </summary>
        /// <returns>Cantidad de calorías de un snack</returns>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos del Snack.
        /// </summary>
        /// <returns>Cadena con el tipo de producto, código de barras, marca, color de empaque y calorías</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
