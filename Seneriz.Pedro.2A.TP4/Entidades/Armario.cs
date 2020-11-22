using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Armario : Antiguedades , ISerializa
    {
        #region Atributos
        public int puertas;
        public int cajones;
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad para obtener el path al lugar en el que se va a serializar el archivo
        /// </summary>
        public string Path
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Seneriz.Pedro.Armario.xml";
            }
        }

        public override string Tipo
        {
            get
            {
                return this.tipo;
            }
        }
        #endregion

        #region Constructores
        public Armario()
        {
        }
        public Armario(double precio, int anio, int puertas, int cajones, int codigo, string tipo)
            :base(precio, anio, codigo, tipo)
        {
            this.puertas = puertas;
            this.cajones = cajones;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Polimorfismo. Muestra todos los datos del armario
        /// </summary>
        /// <returns></returns>
        protected override string AntiguedadesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.AntiguedadesToString());
            sb.AppendLine("Puertas : " + this.puertas);
            sb.AppendLine("Cajones : " + this.cajones);

            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos del armario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.AntiguedadesToString();
        }

        #endregion

        #region Interfaz
        /// <summary>
        /// Interfaz para convertir el archivo a xml. Guarda el archivo en el escritorio
        /// </summary>
        /// <returns></returns>
        public bool Xml()
        {
            try
            {
                using (XmlTextWriter textWriter = new XmlTextWriter(this.Path, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Armario));
                    serializer.Serialize(textWriter, this);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
