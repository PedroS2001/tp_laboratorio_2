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
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /*public static bool Guardar(Jornada jornada)
        {

        }

        public static bool Leer()
        {
        }
        */


        #endregion

        #region Operadores
        
        public static bool operator ==(Jornada j, Alumno a)
        {
            if(j.Alumnos.Contains(a))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.Append("CLASE DE " + this.Clase);
            sb.AppendLine(" POR NOMBRE COMPLETO: " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------->");
            
            return sb.ToString();
        }

    }
}
