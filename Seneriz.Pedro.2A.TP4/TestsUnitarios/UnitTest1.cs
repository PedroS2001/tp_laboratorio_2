using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(CarritoLlenoException))]
        public void CarritoLlenoTest()
        {
            //Arrange
            Carrito<Antiguedades> carrito = new Carrito<Antiguedades>(5);


            Antiguedades a1 = new Mesa(20000, 2000, 4, 8, 111,"Mesa");
            Antiguedades a2 = new Mesa(15000, 1995, 4, 8, 222,"Mesa");
            Antiguedades a3 = new Sillon(25000, 1915, 2, 333,"Sillon");
            Antiguedades a4 = new Sillon(30000, 1967, 3, 444,"Sillon");
            Antiguedades a5 = new Armario(54000, 1990, 3, 6, 555,"Armario");
            Antiguedades a6 = new Armario(42000, 1999, 2, 4, 667,"Armario");

            //Act

            carrito += a1;
            carrito += a2;
            carrito += a3;
            carrito += a4;
            carrito += a5;

            //este no puede agregarlo
            carrito += a6;

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoRepetidoException))]
        public void ElementoRepetidoTest()
        {
            //Arrange
            Carrito<Antiguedades> carrito = new Carrito<Antiguedades>(5);

            Antiguedades a1 = new Mesa(20000, 2000, 4, 8, 111,"Mesa");
            Antiguedades a2 = new Sillon(25000, 1915, 2, 333,"Sillon");
            Antiguedades a3 = new Mesa(15000, 2000, 4, 8, 111,"Mesa");

            //Act
            //a1 y a1 son iguales

            carrito += a1;
            carrito += a2;
            carrito += a3;


            //Assert
        }

        [TestMethod]
        public void ListaAntiguedadesInstanciada()
        {
            Carrito <Antiguedades> carrito = new Carrito<Antiguedades>();

            Assert.IsNotNull(carrito.Elementos);
        }

    }
}
