using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo alumnos
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
        /// Propiedad de Lectura y Escritura del atributo profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que permite escribir o recuperar una jornada específica 
        /// </summary>
        /// <param name="i">Indice de la jornada a escribir/leer</param>
        /// <returns>Jornada especificada en el índice</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }

       /// <summary>
       /// Crea una instancia del objeto Universidad
       /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        /// <summary>
        /// Devuelve los datos de todas las jornadas correspondientes a una universidad
        /// </summary>
        /// <param name="uni">Universidad de la cual se desea obtener los datos de jornadas</param>
        /// <returns>Cadena con datos de clase, profesor y listado de alumnos de todas las jornadas de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno;
            retorno = "JORNADA:\n";
            foreach (Jornada j in uni.Jornadas)
            {
                retorno += j.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Hace públicos los datos del total de jornadas de la universidad
        /// </summary>
        /// <returns>Cadena con datos de clase, profesor y listado de alumnos de todas las jornadas de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Determina si un alumno forma parte de una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si forma parte; false si no</returns>  
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno auxA in g.Alumnos)
            {
                if (auxA == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determina si un alumno NO forma parte de una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si NO forma parte; false caso contrario</returns>  
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Agrega un alumno a una universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad a la que fue agregado el alumno; AlumnoRepetidoException en caso de que el alumno ya pertenezca a la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Determina si un profesor forma parte de una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si forma parte; false si no</returns>  
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (g.Instructores.Contains(i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si un profesor NO forma parte de una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si NO forma parte; false caso contrario</returns> 
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega un profesor a una universidad, si este no pertenece previamente a la misma
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad a la que fue agregado el profesor</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            else
            {
                Console.WriteLine("Profesor ya cargado");
            }
            return u;
        }

        /// <summary>
        /// Busca a un profesor capaz de dar una determinada clase dentro de unaa universidad
        /// </summary>
        /// <param name="u">Universidad a la que debe pertenecer el profesor</param>
        /// <param name="clase">Clase que deberá dictar</param>
        /// <returns>Profesor en caso de encontrarlo; SinProfesorException en caso de no encontrar</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Busca a un profesor que no pueda dar una determinada clase
        /// </summary>
        /// <param name="u">Universidad a la que debe pertenecer el profesor</param>
        /// <param name="clase">Clase que no puede dictar</param>
        /// <returns>Profesor en caso de encontrarlo; null en caso de no encontrar</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Crea una jornada con una nueva clase, un profesor y suma a los alumnos que toman esa clase a la jornada
        /// </summary>
        /// <param name="g">Universidad a la que pertencerá la jornada</param>
        /// <param name="clase">Clase de la jornada</param>
        /// <returns>Universidad a la que pertence la jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProf;
            auxProf = (g == clase);
            Jornada j = new Jornada(clase, auxProf);
            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a);
                }
            }
            g.Jornadas.Add(j);           
            return g;
        }

        /// <summary>
        /// Guarda los datos de una universidad en un archivo formato XML en el directorio donde se encuentra el ejecutable
        /// </summary>
        /// <param name="uni">Universidad que se quiere guardar</param>
        /// <returns>True si logra guardar; ArchivosException si no</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "//Universidad.xml", uni);
        }

        /// <summary>
        /// Lee los datos de una universidad desde un archivo formato XML ubicado en el directorio donde se encuentra el ejecutable
        /// </summary>
        /// <param name="uni">Universidad que se quiere leer</param>
        /// <returns>True si logra guardar; ArchivosException si no</returns>
        public static Universidad Leer()
        {
            Universidad uni = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            if(xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "//Universidad.xml", out uni))
            {
                return uni;
            }
            else
            {
                return null;
            }            
        }
    }
}
