using System;
//Daire sınıfında Yaricap property'si olsun. Alan ve Cevre hesaplanan (read-only) property olarak yazılsın
namespace Soru3
{
    class Daire
    {
        double Yaricap;

        public Daire(double r)
        {
            Yaricap = (r > 0) ? r : 0;
        }

        public double ALan => Yaricap * Yaricap * Math.PI;
        public double Cevre => Yaricap * 2 * Math.PI;

    }

    class Program
    {
        static void Main()
        {
            Daire d1 = new Daire(5);
            Console.WriteLine($"ALan: {d1.ALan}\t Cevre: {d1.Cevre}");
        }
    }
}