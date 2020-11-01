using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Universitario()
            :base()
        {
        }

        /// <summary>
        /// Constructor con parametros que llama al constructor de su clase padre
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">dni del universitario</param>
        /// <param name="nacionalidad">nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Funcion que retorna todos los datos del universitario 
        /// </summary>
        /// <returns>Todos los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NúMERO: " + this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Operadores  
        /// <summary>
        /// Compara dos universitarios y en caso de tener el mismo DNI o el mismo Legajo es que son iguales
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>True si son iguales o false si no</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si dos universitarios son diferentes
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>True si son distintos o false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
