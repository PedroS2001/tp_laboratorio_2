using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Propiedades

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                if(i >= 0 && i < this.Jornadas.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.jornada[i] = value;
                }
                else
                {
                    this.Jornadas.Add(value);
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// constructor por default que inicia las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que guarda los datos de la universidad en formato xml en el documento "universidad.xml"
        /// </summary>
        /// <param name="uni">Universidad de la que se quieren guardar los datos</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> u = new Xml<Universidad>();
            
            return u.Guardar("universidad.xml", uni);
        }

        /// <summary>
        /// Metodo que lee los datos de una universidad que esta en formato xml en el documento "universidad.xml"
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad univXml;
            Xml<Universidad> univ = new Xml<Universidad>();
            univ.Leer("universidad.xml", out univXml);

            return univXml;
        }

        /// <summary>
        /// Devuelve los datos de la universidad. Las jornadas, alumnos y profesores
        /// </summary>
        /// <param name="uni">Universidad que se quieren saber los datos</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// hace publicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Operadores

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// retornará el primer Profesor que no pueda dar la clase. Si todos los profesores pueden dar la clase retorna nulo
        /// </summary>
        /// <param name="u">Universidad en la que se busca</param>
        /// <param name="clase">Clase que se busca profesor</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach(Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    instructor = item;
                }
            }

            return instructor;
        }
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach(Profesor item in g.Instructores)
            {
                if(item == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    return item;
                }
            }
            //en caso de que no retorne ningun profesor que pueda dar la clase lanzara una excepcion 
            throw new SinProfesorException();
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor instructor = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, instructor);

            foreach(Alumno item in g.Alumnos)
            {
                if(item == clase)
                {
                    nuevaJornada += item;
                }
            }

            g.Jornadas.Add(nuevaJornada);

            return g;
        }
        /// <summary>
        /// Se agregara un alumno validando que no esté previamente cargado.
        /// </summary>
        /// <param name="u">Universidad en la que se quiere agregar al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if( u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Se agregara un profesor validando que no esté previamente cargado.
        /// </summary>
        /// <param name="u">Universidad en la que se quiere agregar al profesor</param>
        /// <param name="i">profesor a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if( u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        #endregion

    }

}
