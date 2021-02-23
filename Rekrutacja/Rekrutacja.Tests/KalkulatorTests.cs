using NUnit.Framework;
using Soneta.Types;
using System;

namespace Rekrutacja.Tests
{
    class KalkulatorTests
    {
        [TestCase(10,10,ExpectedResult =20)]
        [TestCase(-10, -10, ExpectedResult = -20)]
        public double Oblicz_Suma(double a, double b)
        {
            return Kalkulator.Oblicz(a, b, '+');
        }


        [TestCase(10, -10, ExpectedResult = 20)]
        [TestCase(-10, 10, ExpectedResult = -20)]
        public double Oblicz_Roznica(double a, double b)
        {
            return Kalkulator.Oblicz(a, b, '-');
        }


        [TestCase(10, 10, ExpectedResult = 100)]
        [TestCase(-10, 10, ExpectedResult = -100)]
        public double Oblicz_Iloczyn(double a, double b)
        {
            return Kalkulator.Oblicz(a, b, '*');
        }

        [TestCase(10, 10, ExpectedResult = 1)]
        [TestCase(-10, 10, ExpectedResult = -1)]
        [TestCase(1,0, ExpectedResult = double.PositiveInfinity)]
        [TestCase(0, 0, ExpectedResult = double.NaN)]
        public double Oblicz_Iloraz(double a, double b)
        {
            return Kalkulator.Oblicz(a, b, '/');
        }


        [Test]
        public void Oblicz_BlednaOperacja_NotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => Kalkulator.Oblicz(1, 1, 's'));
        }
    }
}
