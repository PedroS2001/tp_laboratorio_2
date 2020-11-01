using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un archivo en formato Xml
        /// En caso de encontrar un error lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo">Nombre del archivo en el que se van a guardar las cosas</param>
        /// <param name="datos">Lo que se va a guardar dentro</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter textWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(textWriter, datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        /// <summary>
        /// Funcion para leer un archivo Xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Donde se guardan los datos leidos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader textReader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    datos = (T)serializer.Deserialize(textReader);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }




    }

}
