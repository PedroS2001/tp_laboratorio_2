using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea +,-,/,* o sino devuelve +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            string retorno;

            switch(operador)
            {
                case '-':
                    retorno = "-";
                    break;
                case '*':
                    retorno = "*";
                    break;
                case '/':
                    retorno = "/";
                    break;
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// llama a la anterior para validar el operador y realiza la operacion
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            char aValidar;
            char.TryParse(operador, out aValidar);
            operador = Calculadora.ValidarOperador(aValidar);
            

            switch (operador)
            {
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        retorno = num1 / num2;
                    break;
                default:
                    retorno = num1 + num2;
                    break;
            }
            return retorno;
        }

    }
}
