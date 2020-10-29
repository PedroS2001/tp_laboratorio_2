using System;
using System.Collections.Generic;
using System.Linq;
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
           //this.alumnos 
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



    }
}
