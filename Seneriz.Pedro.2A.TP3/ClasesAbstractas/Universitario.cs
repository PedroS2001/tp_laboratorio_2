using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        public Universitario()
            :base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }


        #endregion

        #region Metodos

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NúMERO : " + this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Operadores
        
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.Equals(pg2))
            {
                if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
