using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true, Encoding.UTF8))
                {
                    sw.WriteLine(datos);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }



        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    return true;    
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

        }
    }
}
