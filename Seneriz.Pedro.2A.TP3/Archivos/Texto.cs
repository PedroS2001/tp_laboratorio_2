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
        /// <summary>
        /// Funcion para guardar un Archivo en formato de Texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo en el que se van a guardar los datos</param>
        /// <param name="datos">Lo que se va a guardar dentro del archivo</param>
        /// <returns></returns>
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


        /// <summary>
        /// funcion para leer de un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del Archivo del que se quiere leer</param>
        /// <param name="datos">Donde va a guardar los datos leidos</param>
        /// <returns></returns>
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
