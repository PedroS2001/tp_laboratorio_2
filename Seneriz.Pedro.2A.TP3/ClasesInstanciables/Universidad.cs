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

        /*
        public Jornada this[int i]
        {

        }
        */
        #endregion

        public Universidad()
        {
        }

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
            return !(u == clase);
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(g.Alumnos.Contains(a))
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            if(g.Instructores.Contains(i))
            {
                return true;
            }
            return false;
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    g.Jornadas.Add(new Jornada(clase,item));
                    break;
                }
            }
            foreach(Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    //ANADIR ALUMNOS
                }

            }
         
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(!(u.Alumnos.Contains(a)))
            {
                u.Alumnos.Add(a);
            }
            else
            {
                //EXCEPCION ALUMNOREPETIDOECXEPTION
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(!(u.Instructores.Contains(i)))
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        #endregion




    }

}
