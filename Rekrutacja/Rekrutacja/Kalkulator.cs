using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    public static class Kalkulator
    {

        public static double Oblicz(double a, double b, char operacja)
        {
            switch (operacja)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default:
                    throw new NotImplementedException($"Operacja {operacja} nie została zaimplementowana w {nameof(Kalkulator)}");
            }
        }
    }
}
