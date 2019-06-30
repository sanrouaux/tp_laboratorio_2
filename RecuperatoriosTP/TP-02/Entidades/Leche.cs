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
        /// <summary>
        /// Enumerado de tipos de leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }

        private ETipo tipo;

        /// <summary>
        /// Propiedad de lectura de las calorías de la leche
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Crea una instancia de la clase Leche a partir de los parámetros recibidos
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Código de barras de la leche</param>
        /// <param name="color">Color de empaque de la leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            :this(marca, patente, color, ETipo.Entera)
        {           
        }

        /// <summary>
        /// Crea una instancia de la clase Leche a partir de los parámetros recibidos
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Código de barras de la leche</param>
        /// <param name="color">Color de empaque de la leche</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }       

        /// <summary>
        /// Muestra la información de la leche
        /// </summary>
        /// <returns>Cadena con todos los datos de la leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
