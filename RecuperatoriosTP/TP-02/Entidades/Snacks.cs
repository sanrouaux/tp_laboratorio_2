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
        /// Crea una instancia de la clase Snacks
        /// </summary>
        /// <param name="marca">Marca del Snack</param>
        /// <param name="patente">Código de barras del Snack</param>
        /// <param name="color">Color de empaque del Snack</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Propiedad de lectura de las calorías del Snack
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Muestra la información sobre el Snack 
        /// </summary>
        /// <returns>Cadena con los datos del Snack</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
