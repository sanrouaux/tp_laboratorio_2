using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Crea una instancia del objeto con los valores de sus atributos por default 
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Crea una instancia del objeto Alumno con los valores pasados por parámetro
        /// </summary>
        /// <param name="id">Id del alumno</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Crea una instancia del objeto Alumno con los valores pasados por parámetro
        /// </summary>
        /// <param name="id">Id del alumno</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Devuelve la clase que toma el alumno
        /// </summary>
        /// <returns>Cadena con los datos de la clase toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString() + "\n";
        }

        /// <summary>
        /// Devuelve datos del alumno
        /// </summary>
        /// <returns>Cadena con nombre, apellido, nacionalidad, legajo, estado de cuenta, clase que toma</returns>
        protected override string MostrarDatos()
        {
            string retorno;
            retorno = base.MostrarDatos(); 
            retorno += "\nESTADO DE CUENTA: "; 
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                retorno += "Cuota al día";
            }
            else
            {
                retorno += this.estadoCuenta.ToString();
            }
            retorno += "\n" + this.ParticiparEnClase();
            return retorno;
        }

        /// <summary>
        /// Hace públicos los datos del alumno
        /// </summary>
        /// <returns>Cadena con nombre, apellido, nacionalidad, legajo, estado de cuenta, clase que toma</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Determina si un alumno pertenece a una clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a la que puede pertencer</param>
        /// <returns>True si el alumno pertenece a la clase y tiene cuota al día; false en caso contrariol</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si un alumno NO pertenece a una clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el alumno NO pertenece a la clase; false en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
