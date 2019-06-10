using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Crea una instancia del objeto con los valores de sus atributos por default 
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Crea una instancia del objeto Profesor con los valores pasados por parámetro y dos clases al azar que dictará
        /// </summary>
        /// <param name="id">Id del profesor</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Atribuye dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {           
            for (int i = 0; i < 2; i++)
            {    
                switch(random.Next(0, 4))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;

                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;

                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;

                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra las clases que dicta el profesor
        /// </summary>
        /// <returns>Cadena con los datos de las clases que dicta el profesor</returns>
        protected override string ParticiparEnClase()
        {
            string retorno;
            retorno = "CLASES DEL DIA:\n";
            foreach(Universidad.EClases c in this.clasesDelDia)
            {
                retorno += c.ToString();
                retorno += "\n";
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve datos del profesor
        /// </summary>
        /// <returns>Cadena con nombre, apellido, nacionalidad, legajo, clases que dicta</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Hace públicos los datos del profesor
        /// </summary>
        /// <returns>Cadena con nombre, apellido, nacionalidad, legajo, estado de cuenta, clase que dicta</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Determina si un profesor dicta una clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a determinar si dicta</param>
        /// <returns>True si el profesor dicta la clase; false en caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if(i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determina si un profesor NO dicta una clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True si el profesor NO dicta la clase; false en caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
