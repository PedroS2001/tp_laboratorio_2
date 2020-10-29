using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        #region Constructores

        static Profesor()
        {
        }
        private Profesor()
        {
            _randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
        }


        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DIA " + this.clasesDelDia.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue(new EClases());
            this.clasesDelDia.Enqueue(new EClases());
        }

        #endregion

        #region Operadores

        public static bool operator ==(Profesor i, EClases clase)
        {
            if(i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion


    }
}
