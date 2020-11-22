using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CarritoLlenoException : Exception
    {
        public CarritoLlenoException()
            : base("EL CARRITO ESTA LLENO")
        {
        }

        public CarritoLlenoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
