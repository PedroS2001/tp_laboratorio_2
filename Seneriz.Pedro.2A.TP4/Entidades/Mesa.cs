using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mesa : Antiguedades
    {
        #region Atributos
        private int patas;
        private int capacidad;
        #endregion

        #region Propiedades
        public int Patas
        {
            get
            {
                return this.patas;
            }
        }
        public int Capacidad
        {
            get
            {
                return this.capacidad;
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
        public Mesa(double precio, int anio, int patas, int capacidad, int codigo, string tipo)
            :base(precio, anio, codigo, tipo)
        {
            this.patas = patas;
            this.capacidad = capacidad;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve una cadena con todos los datos de la mesa
        /// </summary>
        /// <returns></returns>
        protected override string AntiguedadesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.AntiguedadesToString());
            sb.AppendLine("Patas : " + this.patas);
            sb.AppendLine("Capacidad : " + this.capacidad);

            return sb.ToString();
        }

        /// <summary>
        /// Hace visibles los datos de la mesa
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.AntiguedadesToString();
        }

        #endregion
    }
}
