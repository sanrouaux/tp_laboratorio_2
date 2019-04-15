using System;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            operador = Calculadora.ValidarOperador(operador);

            switch(operador)
            {
                case "+":
                    return num1 + num2;
                    break;

                case "-":
                    return num1 - num2;
                    break;

                case "/":
                    return num1 / num2;
                    break;

                case "*":
                    return num1 * num2;
                    break;

                default:
                    return 0;
                    break;
            }
        }

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
