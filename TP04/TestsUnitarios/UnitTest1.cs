using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba que la lista de paquetes de un correo esté instanciada
        /// </summary>
        [TestMethod]
        public void ListaDePaquetesNula()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);      
        }

        /// <summary>
        /// Comprueba que no se pueden cargar dos paquetes con el mismo trackingID y, al intentar hacerlo, que se lance una
        /// excepción del tipo TrackingIdRepetidoException 
        /// </summary>
        [TestMethod]
        public void DosPaquetesConMismoTrackingID()
        {
            Correo c = new Correo();
            Paquete paq1 = new Paquete("Belgrano 1224", "123-543-2345");
            Paquete paq2 = new Paquete("San Martin 987", "123-543-2345");
            
            try
            {
                c += paq1;
                c += paq2;
                Assert.Fail("Error. Carga dos paquetes con el mismo TrackingID");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
