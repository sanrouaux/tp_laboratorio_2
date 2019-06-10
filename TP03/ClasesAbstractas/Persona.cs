using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de Escritura del atributo dni 
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Crea una instancia del objeto con los valores de sus atributos por default 
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Crea una instancia del objeto Persona con los valores pasados por parámetro
        /// </summary>
        /// <param name="nombre">Atributo nombre del objeto Persona</param>
        /// <param name="apellido">Atributo apellido del objeto Persona</param>
        /// <param name="nacionalidad">Atributo nacionalidad del objeto Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Crea una instancia del objeto Persona con los valores pasados por parámetro
        /// </summary>
        /// <param name="nombre">Atributo nombre del objeto Persona</param>
        /// <param name="apellido">Atributo apellido del objeto Persona</param>
        /// <param name="dni">Atributo DNI del objeto Persona</param>
        /// <param name="nacionalidad">Atributo nacionalidad del objeto Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Crea una instancia del objeto Persona con los valores pasados por parámetro
        /// </summary>
        /// <param name="nombre">Atributo nombre del objeto Persona</param>
        /// <param name="apellido">Atributo apellido del objeto Persona</param>
        /// <param name="dni">Atributo DNI del objeto Persona</param>
        /// <param name="nacionalidad">Atributo nacionalidad del objeto Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Valida que el número de DNI recibido se encuentre en el rango permitido y que el número sea correcto en relación a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>DNI si el numero se encuentra en el rango correcto y no hay incompatibilidad con la nacionalidad
        /// Excepciones: 
        /// NacionalidadInvalidadException si hay incompatibilidad con nacionalidad
        /// DniInvalidoException si el número está fuera de rango</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (dato > 0 && dato < 100000000)
            {
                if (nacionalidad == ENacionalidad.Argentino && (dato > 0 && dato < 90000000))
                {
                    return dato;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato < 100000000))
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida que el string DNI recibido no tenga caracteres extraños, se encuentre en rango y sea compatible con nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>DNI si el numero de DNI es correcto
        /// Excepciones: 
        /// NacionalidadInvalidadException si hay incompatibilidad con nacionalidad
        /// DniInvalidoException si el número está fuera de rango o tiene caracteres extraños</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int i;
            if (int.TryParse(dato, out i) == true)
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida que nombre y apellido no tengan caracteres extraños
        /// </summary>
        /// <param name="dato">nombre/apellido de la persona</param>
        /// <returns>El nombre si la validación es correcta; null si no lo es</returns>
        private static string ValidarNombreApellido(string dato)
        {
            char[] array;
            array = dato.ToArray();
            for (int i = 0; i < array.Count(); i++)
            {
                if (!char.IsLetter(array[i]))
                {
                    return null;
                }
            }
            return dato;
        }

        /// <summary>
        /// Presenta datos completos de la persona
        /// </summary>
        /// <returns>Cadena con nombre, apellido y nacionalidad</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\nNACIONALIDAD: " +
                this.Nacionalidad.ToString() + "\n\n";
                
        }
    }
}
