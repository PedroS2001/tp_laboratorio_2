using Excepciones;
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
                this.apellido = ValidarNombreApellido(value); 
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
                this.nombre = ValidarNombreApellido(value);
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
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
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
            if(dato > 1 || dato < 99999999)
            {

                if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) || (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;

            if(int.TryParse(dato, out aux))
            {
                return ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException();
            }

        }

        private string ValidarNombreApellido(string dato)
        {
            foreach(char item in dato)
            {
                if (!(char.IsLetter(item) || char.IsWhiteSpace(item)))
                {
                    return null;
                }
            }

            return dato;
        }
        
        #endregion

    }

}
