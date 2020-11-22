using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrito<Antiguedades> cAntiguedades = new Carrito<Antiguedades>(4);
            Carrito<Sillon> cSillones = new Carrito<Sillon>(5);
            Carrito<Mesa> cMesas = new Carrito<Mesa>(2);
            Carrito<Armario> cArmario = new Carrito<Armario>(3);


            Mesa m1 = new Mesa(20000, 2000, 4, 8, 111, "Mesa");
            Mesa m2 = new Mesa(15000, 1995, 4, 8, 222, "Mesa");
            Mesa m3 = new Mesa(12345, 1900, 6, 8, 999, "Mesa");
            Sillon s3 = new Sillon(25000, 1915, 2, 333, "Sillon");
            Sillon s4 = new Sillon(30000, 1967, 3, 444, "Sillon");
            Armario a5 = new Armario(54000, 1990, 3, 6, 555, "Armario");
            Armario a6 = new Armario(42000, 1999, 2, 4, 667, "Armario");
            Antiguedades an7 = new Armario(42000, 1999, 2, 5, 777, "Armario");
            Antiguedades an8 = new Armario(42000, 1999, 3, 4, 888, "Armario");

            try
            {
                cAntiguedades += m1;
                cAntiguedades += s3;
                cAntiguedades += a5;
                cAntiguedades += an7;
                //no se puede. el carrito esta lleno
                cAntiguedades += m2;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            { 
                cSillones += s3;
                cSillones += s4;
                //no se puede el producto ya esta en el carrito
                cSillones += s3;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                cMesas += m1;
                cMesas += m2;
                //no se puede el carrito esta lleno
                cMesas += m3;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("***********************************************");
            Console.WriteLine(cSillones.ToString());
            Console.WriteLine(cAntiguedades.ToString());
            Console.WriteLine(cMesas.ToString());



            Console.WriteLine("***********************************************");
            //Vacio el carrito de mesas
            cMesas.Elementos.Clear();
            Console.WriteLine(cMesas.ToString());


            Console.WriteLine("***********************************************");
            try
            {
                if(a5.Xml())
                {
                    Console.WriteLine("Se guardo el xml en el escritorio");
                }
                else
                {
                    Console.WriteLine("NO SE PUDO guardar el xml");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("***********************************************");
            if(Ticketadora.ImprimirTicket(cSillones.ToString()))
            {
                Console.WriteLine("Se imprimio el ticket en \"Mis documentos\"");
            }
            else
            {
                Console.WriteLine("NO SE PUDO IMPRIMIR TICKET");
            }







            Console.ReadLine();


        }
    }
}
