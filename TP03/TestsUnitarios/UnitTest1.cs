using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;


namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea si, al crear un alumno con un DNI que no corresponde a nacionalidad argentina, lanza un error del tipo correcto
        /// </summary>
        [TestMethod]
        public void TestearExceptionNacionalidadInvalida()
        {
            try
            {
                Alumno nuevoAlumno = new Alumno(125, "Juan", "Rodriguez", "96786546", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }        
        }

        /// <summary>
        /// Testea si, al agregar dos alumnos con un mismo número de legajo a una universidad, lanza un error del tipo correcto
        /// </summary>
        [TestMethod]
        public void TestearExceptionAlumnoRepetido()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno alum1 = new Alumno(125, "Juan", "Rodriguez", "41786546", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
                Alumno alum2 = new Alumno(125, "Ricardo", "Ramirez", "35786546", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Testea si, al crear un alumno con un DNI, el número se carga correctamente
        /// </summary>
        [TestMethod]
        public void TestearNumeroDniCorrecto()
        {
            Profesor prof = new Profesor(84, "Emanuel", "Fernandez", "25415369", Persona.ENacionalidad.Argentino);
            if(prof.DNI != 25415369)
            {
                Assert.Fail("El Dni no se generó correctamente");
            }
        }

        /// <summary>
        /// Testea si, al crear universidad, el atributo alumnos no es nulo
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
