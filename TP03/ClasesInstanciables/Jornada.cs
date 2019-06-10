using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada 
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de Lectura y Escritura de la lista de alumno de la jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura de la clase de la jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del profesor de la jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        
        /// <summary>
        /// Inicializa la lista de alumno
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Crea una instancia de jornada
        /// </summary>
        /// <param name="clase">Clase de la jornada</param>
        /// <param name="instructor">Profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Determina si un alumno participa de la clase de la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si forma parte; false si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si un alumno NO participa de la clase de la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si NO forma parte; false si forma parte</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Jornada a la que fue agregado el alumno</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                bool presente = false;
                foreach(Alumno auxA in j.alumnos)
                {
                    if(auxA == a)
                    {                        
                        presente = true;
                        break;
                    }
                }
                if(!(presente == true))
                {
                    j.alumnos.Add(a);
                }
                else
                {
                    Console.WriteLine("No se pudo agregar al alumno. Ya pertenece a la clase");
                }
            }
            else
            {
                Console.WriteLine("No se pudo agregar al alumno. Se encuentra inscripto en otra clase o presenta deuda");
            }
            return j;
        }

        /// <summary>
        /// Muestra los datos de una jornada
        /// </summary>
        /// <returns>Cadena con clase, profesor y listado de alumnos de la jornada</returns>
        public override string ToString()
        {
            string retorno;
            retorno = "CLASE DE " + this.clase.ToString() + " POR " + this.instructor.ToString() + "\n";
            retorno += "ALUMNOS:\n";
            foreach (Alumno a in this.alumnos)
            {
                retorno += a.ToString();
            }
            retorno += "<-------------------------------------------------------------->\n";
            return retorno;
        }

        /// <summary>
        /// Guarda la información de una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Información a ser guardada</param>
        /// <returns>True si logra guardar la jornada; ArchivosException si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(AppDomain.CurrentDomain.BaseDirectory + "//Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Recupera la información de una jornada desde un archivo de texto
        /// </summary>
        /// <returns>Cadena con información de la jornada si logra leer el archivo; ArchivosException si no</returns>
        public static string Leer()
        {
            string retorno;
            Texto texto = new Texto();
            texto.Leer(AppDomain.CurrentDomain.BaseDirectory + "//Jornada.txt", out retorno);
            return retorno;
        }
    }
}
