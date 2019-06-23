using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {  
        /// <summary>
        /// Evento
        /// </summary>
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Delegado
        /// </summary>
        /// <param name="sender">Objeto que emite el evento</param>
        /// <param name="e">Otros datos del origen del evento</param>
        public delegate void DelegadoEstado(object sender, EventArgs e);
        
        /// <summary>
        /// Enumerado Estado del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        /// <summary>
        /// Atributos
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Propiedad de lectura/escritura del atributo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura del atributo que da cuenta del estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura del atributo trackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Crea una instancia de la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion en la que debe ser entregado el paquete</param>
        /// <param name="trackingID">Numero de identificación del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Tras esperar 4 segundos, cambia el estado del paquete y lanza un evento para informarlo. Finalmente, guarda 
        /// la información del paquete en la base de datos  
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);            
            this.Estado = EEstado.EnViaje;
            this.InformaEstado(this, new EventArgs());
            Thread.Sleep(4000);
            this.Estado = EEstado.Entregado;
            this.InformaEstado(this, new EventArgs());
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Permite obtener los datos de un paquete
        /// </summary>
        /// <param name="elemento">Paquete del cual se intentan obtener los datos</param>
        /// <returns>Cadena con los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paq = (Paquete)elemento;
            return string.Format("{0} para {1}", paq.TrackingID, paq.DireccionEntrega);
        }

        /// <summary>
        /// Permite obtener los datos de un paquete
        /// </summary>
        /// <returns>Cadena con los datos del paquete</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Permite saber si dos paquetes tienen igual número de identificación
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>True si ambos paquetes tienen igual número de ID; falso en caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permite saber si dos paquetes NO tienen igual número de identificación
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>True si los paquetes NO tienen igual número de ID; falso en caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }       
    }
}
