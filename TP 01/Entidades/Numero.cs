using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        //ATRIBUTOS
        private double _numero;


        //CONSTRUCTORES
        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string strNumero)
        {
            this._numero = double.Parse(strNumero);
        }


        //PROPIEDAD
        private string SetNumero
        {
            set
            {
                _numero = Numero.ValidarNumero(value);
            }
        }


        //METODOS
        private static double ValidarNumero(string strNumero)
        {
            double dblNumero;
            if (double.TryParse(strNumero, out dblNumero))
            {
                return dblNumero;
            }
            else
            {
                return 0;
            }
        }


        //SOBRECARGA DE OPERADORES
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2._numero != 0)
            {
                return n1._numero / n2._numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }


        //METODOS CONVERSORES
        public static string BinarioDecimal(string binario)
        {
            Regex reg = new Regex("[0-1]");
            if(!String.IsNullOrEmpty(binario) && reg.IsMatch(binario))
            {
                return Convert.ToString(Convert.ToInt32(binario, 2), 10);
            }
            else
            {
                return "Valor inválido";
            }            
        }


        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((uint)numero, 2);
        }


        public static string DecimalBinario(string numero)
        {            
            if (!String.IsNullOrEmpty(numero))
            {
                return Numero.DecimalBinario(Math.Abs(Convert.ToDouble(numero)));
            }
            else
            {
                return "Valor inválido";
            }
        }
    }
}
