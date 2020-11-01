using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Constructores

        public Alumno() : base()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");
            switch(this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("Cuota al dia");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("Alumno becado");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("Alumno deudor");
                    break;
            }
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        public static bool operator !=(Alumno a, EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
