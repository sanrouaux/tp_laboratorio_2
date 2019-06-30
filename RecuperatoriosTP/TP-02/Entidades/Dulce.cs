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
        /// Crea una instancia de la clase Dulce
        /// </summary>
        /// <param name="marca">Marca del Dulce</param>
        /// <param name="patente">Código de barras del Dulce</param>
        /// <param name="color">Color de empaque del Dulce</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            :base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Propiedad de lectura de las calorías del dulce
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Muestra la información sobre el dulce 
        /// </summary>
        /// <returns>Cadena con los datos del dulce</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
