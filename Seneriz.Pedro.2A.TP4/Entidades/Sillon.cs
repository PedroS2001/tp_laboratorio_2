using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sillon : Antiguedades
    {
        #region Atributos
        private int almohadones;
        #endregion

        #region Propiedades
        public int Almohadones
        {
            get
            {
                return this.almohadones;
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

        #region Constructor
        public Sillon(double precio, int anio, int almohadones, int codigo, string tipo)
            :base(precio, anio, codigo, tipo)
        {
            this.almohadones = almohadones;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve una cadena con todos los datos del sillon
        /// </summary>
        /// <returns></returns>
        protected override string AntiguedadesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.AntiguedadesToString());
            sb.AppendLine("Almohadones : " + this.almohadones);

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos todos los datos del sillon
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.AntiguedadesToString();
        }

        #endregion
    }
}
