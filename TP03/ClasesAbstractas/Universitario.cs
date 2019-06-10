using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Crea una instancia del objeto con los valores de sus atributos por default 
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Crea una instancia del objeto Universitario con los valores pasados por parámetro
        /// </summary>
        /// <param name="legajo">Número de legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Metodo abstracto que devuelve la/s clase/s que toma/dicta el alumno o profesor
        /// </summary>
        /// <returns>Cadena con los datos de la/s clase/s tomada/dictada</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara una instancia de universitario con un objeto de cualquier tipo
        /// </summary>
        /// <param name="obj">Objeto a ser comparado con el universitario</param>
        /// <returns>True si el objeto comparado es de igual tipo y coincide en legajo o dni
        /// False en caso contrario</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Muestra datos del universitario
        /// </summary>
        /// <returns>Cadena con nombre, apellido, nacionalidad y legajo</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "LEGAJO NUMERO: " + this.legajo.ToString() + "\n";
        }

        /// <summary>
        /// Determina si dos universitarios coinciden en tipo y legajo o tipo y dni
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Otro universitario a comparar</param>
        /// <returns>True si coinciden; false si no coinciden</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si dos universitarios NO coinciden en tipo y legajo, o bien tipo y dni
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Otro universitario a comparar</param>
        /// <returns>True si NO coinciden; false si coinciden</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
