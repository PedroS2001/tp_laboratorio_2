using EntidadesAbstractas = ClasesAbstractas;
using System;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoTest()
        {
            //Arrange
            Universidad uni = new Universidad();

            //tienen el mismo dni
            Alumno a1 = new Alumno(92, "Angel", "Romero", "95123654", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(10, "Oscar", "Romero", "95123654", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            //Act
            uni += a1;

            uni += a2;

            //Assert
        }


        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidaTest()
        {
            Alumno alumno = new Alumno(9, "El Pepe", "Sand", "52264456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoTest()
        {
            Alumno alumno = new Alumno(18, "Pablo", "Perez", "12e4s678", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
        }

        [TestMethod]
        public void ListaAlumnosInstaciadaTest1()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
        }

        [TestMethod]
        public void ListaProfesoresInstaciadaTest1()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }
    }
}
