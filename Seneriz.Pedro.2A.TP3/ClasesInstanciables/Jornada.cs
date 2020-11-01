using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region propiedades

        public List<Alumno> Alumnos
        {
            get 
            {
                return this.alumnos; 
            }
            set 
            {
                this.alumnos = value; 
            }
        }

        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por default. Inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que recibe clase y profesor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que guarda una jornada en un archivo de texto llamado "jornada.txt"
        /// </summary>
        /// <param name="jornada">Jornada que quiere ser guardada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto nuevoTexto = new Texto();
            return nuevoTexto.Guardar("jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Metodo que lee un archivo de texto llamado "jornada.txt"
        /// </summary>
        /// <returns>Retorna en formato string los datos de jornada leidos</returns>
        public static string Leer()
        {
            string retorno;
            Texto textoLeido = new Texto();
            textoLeido.Leer("jornada.txt", out retorno);

            return retorno;
        }
        /// <summary>
        /// Muestra todos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this.Clase);
            sb.AppendLine(" POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------->");

            return sb.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno item in j.Alumnos)
            {
                if(item.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Una Jornada será desigual a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada controlando que no este previamente cargado
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion

    }
}
