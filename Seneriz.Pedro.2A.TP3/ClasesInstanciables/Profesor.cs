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
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico que dara un valor al atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor con parametros que llama al constructor de la clase base, inicializa la lista de clases del dia y le asigna 2 clases random
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna todos los datos del profesor y las clases que da
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna las clases que da el profesor en el dia
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// Le asigna dos clases random al profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 3));
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            if(i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
