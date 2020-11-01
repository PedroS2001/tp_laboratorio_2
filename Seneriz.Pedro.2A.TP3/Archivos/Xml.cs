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
