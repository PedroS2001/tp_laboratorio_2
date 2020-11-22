using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticketadora
    {
        /// <summary>
        /// Imprime un documento de texto con los datos de la venta
        /// El archivo se guarda en la carpeta "mis documentos" bajo el nombre de "tickets"
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns></returns>
        public static bool ImprimirTicket(string carrito)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", true, Encoding.UTF8))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(carrito);
                    sw.WriteLine("");
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
