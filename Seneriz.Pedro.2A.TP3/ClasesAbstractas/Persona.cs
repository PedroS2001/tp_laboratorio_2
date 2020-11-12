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
        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad que valida que el apellido sea valido antes de asignarlo
        /// </summary>
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
        /// <summary>
        /// Propiedad que valida que el nombre sea valido antes de asignarlo
        /// </summary>
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

        /// <summary>
        /// Propiedad que valida que el dni sea valido antes de asignarlo
        /// </summary>
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

        /// <summary>
        /// Propiedad que valida que el dni en formato cadena sea valido antes de asignarlo
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad que asigna la nacionalidad
        /// </summary>
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
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona en formato de cadena</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Convierte los datos de la persona en string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.AppendLine(this.Apellido + ", " + this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());

            return sb.ToString();
        }
        
        /// <summary>
        /// Valida que el dni sea valido, pudiendo lanzar dos excepciones en caso contrario
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni de la persona</param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que el dni pasado en formato string sea un dni valido. pudiendo lanzar excepciones en caso contrario
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni de la persona</param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que una cadena sea un nombre valido, siendo todas letras o espacios
        /// </summary>
        /// <param name="dato">Cadena que se va a validar</param>
        /// <returns></returns>
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
