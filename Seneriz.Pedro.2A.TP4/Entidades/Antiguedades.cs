using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta de la que heredaran todos los productos
    /// </summary>
    public abstract class Antiguedades
    {
        #region Atributos
        public double precio;
        public int anio;
        public int codigo;
        public string tipo;
        #endregion

        #region Propiedad
        public abstract string Tipo { get; }
        #endregion

        #region Constructores
        public Antiguedades()
        {
        }
        public Antiguedades(double precio, int anio, int codigo, string tipo)
        {
            this.precio = precio;
            this.anio = anio;
            this.codigo = codigo;
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelte una cadena con todos los datos de la antiguedad
        /// </summary>
        /// <returns></returns>
        protected virtual string AntiguedadesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tipo: " + this.tipo);
            sb.AppendLine("Codigo: " + this.codigo);
            sb.AppendLine("Precio: " + this.precio);
            sb.Append("Año: " + this.anio);

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de la antiguedad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.AntiguedadesToString();
        }

        public static bool operator ==(Antiguedades a, Antiguedades b)
        {
            if (a.codigo == b.codigo && a.Tipo == b.Tipo)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Antiguedades a, Antiguedades b)
        {
            //para que no falle al generar el codigo
            if (b is null)
            {
                return false;
            }
            return !(a == b);
        }
        #endregion

    }
}
