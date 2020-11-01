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
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #region Metodos

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> u = new Xml<Universidad>();
            
            return u.Guardar("universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Universidad univXml;
            Xml<Universidad> univ = new Xml<Universidad>();
            univ.Leer("universidad.xml", out univXml);

            return univXml;

        }
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
