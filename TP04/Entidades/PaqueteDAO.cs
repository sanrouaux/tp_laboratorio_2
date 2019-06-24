using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        /// <summary>
        /// Evento relacionado a un error de conexión con base de datos
        /// </summary>
        public static event DelegadoErrorBaseDeDatos ErrorBaseDeDatos;

        /// <summary>
        /// Delegado relacionado a error de conexión con base de datos
        /// </summary>
        /// <param name="mensaje">Detalle del error</param>
        public delegate void DelegadoErrorBaseDeDatos(string mensaje);

        /// <summary>
        /// Atributos
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Crea una instancia de la Clase PaqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexion_bd);
            comando = new SqlCommand();            
        }

        /// <summary>
        /// Inserta un paquete en la base de datos asociada a la aplicación
        /// </summary>
        /// <param name="p">Paquete a insertar</param>
        /// <returns>True si logró insertar el paquete. False en caso contrario. Exception si </returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega
                + "', '" + p.TrackingID + "', 'Rouaux,Santiago')";

            try
            {                
                conexion.Open();
                if(comando.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }          
            }
            catch (Exception)
            {     
                PaqueteDAO.ErrorBaseDeDatos("No se logró conexión con la base de datos");
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }            
            return retorno;
        }
    }
}
