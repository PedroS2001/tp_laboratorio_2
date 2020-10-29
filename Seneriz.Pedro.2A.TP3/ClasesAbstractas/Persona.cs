 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }


        #region Propiedades
        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }
            set 
            { 
                this.apellido = value; 
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = Convert.ToInt32(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.AppendLine(this.Apellido + ", " + this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());

            return sb.ToString();
        }
        
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad,dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = Convert.ToInt32(dato);
            //Es necesario para saber que se pudo convertir y tiene 8 caracteres. en caso de no poder convertirse el valor de aux sera 0
            if(aux.ToString().Length == 8)
            {
                if((nacionalidad == ENacionalidad.Argentino && aux >= 1 && aux <= 89999999) || (nacionalidad == ENacionalidad.Extranjero && aux >= 90000000 && aux <= 99999999))
                {
                    return aux;
                }
                else 
                {
                    //NACIONALIDADINVALIDAEXEPTION
                }
            }
            else
            {
                //DNIINVALIDOEXCEPCION
            }

            return -1;
        }

        /*private string ValidarNombreApellido(string dato)
        {
            

        }*/
        

        #endregion



    }

}
