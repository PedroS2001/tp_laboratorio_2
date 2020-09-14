using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double numero;

        #region metodos

        private void setNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// llama a la funcion que valida que sea un numero binario y luego lo convierte en un numero decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            if (this.EsBinario(binario))
                binario = Convert.ToInt32(binario, 2).ToString();
            else
                binario = "Valor invalido";
            return binario;
        }

        /// <summary>
        /// Convierte un double en un string binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string resultado;

            if (numero > 0)
                resultado = Convert.ToString((int)numero, 2);
            else
                resultado = "Valor invalido";
            return resultado;
        }

        /// <summary>
        /// toma un numero como string y lo convierte en binario como string. si no puede devuelve valor invalido
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            bool respuesta = int.TryParse(numero, out int resultado);
            if (respuesta)
            {
                numero = DecimalBinario(resultado);
            }
            return numero;
        }

        /// <summary>
        /// valida que un string sea un numero binario, es decir 0s y 1s
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            char a;
            bool retorno = true;
            for(int i = 0; i < binario.Length; i++)
            {
                a = binario[i];
                if(a != '0' && a != '1')    //Si algun numero es distinto de 1 o 0 devuelve false
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Recibe un string y valida que sea un numero valido. si no es, devuelve 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            bool result = double.TryParse(strNumero, out double retorno);
            if (result)
                return retorno;
            else
                return 0;
        }

        #endregion

        #region Constructores

        public Numero()
        {
            setNumero("0");
        }

        public Numero(double numero)
        {
            string strNumero = numero.ToString();
            setNumero(strNumero);
        }

        public Numero(string strNumero)
        {
            setNumero(strNumero);
        }
        #endregion

        #region Operadores sobrecargados

        public static double operator -(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1.numero - n2.numero;
            return retorno;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1.numero + n2.numero;
            return retorno;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1.numero * n2.numero;
            return retorno;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;

            if (n2 != 0)
                retorno = n1.numero / n2.numero;
            else
                retorno = double.MinValue;
            return retorno;
        }

        public static bool operator != (Numero n1, double n2)
        {
            bool retorno = false;

            if(n1.numero != n2)
                retorno = true;

            return retorno;
        }

        public static bool operator ==(Numero n1, double n2)
        {
            bool retorno = false;

            if (n1.numero == n2)
                retorno = true;

            return retorno;
        }
        #endregion


    }

}
