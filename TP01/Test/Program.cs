using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Numero.BinarioDecimal("1011101011")); //747
            Console.WriteLine(Numero.DecimalBinario(4.6)); //100
            Console.WriteLine(Numero.DecimalBinario("5.25")); //101
            Console.ReadKey();
            
        }
    }
}
