using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Profesor.random = new Random();
        }
        public Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();

        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            foreach(EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 3));
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
