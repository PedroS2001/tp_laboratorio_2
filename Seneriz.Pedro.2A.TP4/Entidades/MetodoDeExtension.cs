using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Metodo de extension para informar el mensaje de una excepcion
    /// </summary>
    public static class MetodoDeExtension
    {
        public static string InformarError(this CarritoLlenoException car)
        {
            return car.Message;
        }
    }
}
