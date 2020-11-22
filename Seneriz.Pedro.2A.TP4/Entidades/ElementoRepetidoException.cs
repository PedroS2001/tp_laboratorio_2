using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ElementoRepetidoException : Exception
    {
        public ElementoRepetidoException()
            :base("El elemento ya se encuentra en el carrito")
        {
        }

        public ElementoRepetidoException(string message)
            :base(message)
        {
        }
    }
}
