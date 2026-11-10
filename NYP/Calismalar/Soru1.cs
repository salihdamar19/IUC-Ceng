/*
Dikdortgen adında bir sınıf yazın. Genislik ve Yukseklik property'leri, AlanHesapla() ve CevreHesapla()
metotları olsun. Negatif değer atanmasını engelleyin.
*/
using System;
using System.Security.Cryptography;
namespace Soru1
{
    class Rect
    {
        double Genislik;
        double Yukseklik;

        public Rect(double genislik, double yukseklik)
        {
            if(genislik < 0 || yukseklik < 0)
            {
                Console.WriteLine("Genislik veya yukseklik sifirdan kucuk olamaz.");
            }
            else
            {
                Genislik = genislik;
                Yukseklik = yukseklik;
            }

        }

        public double AlanHesapla()
        {
            return Genislik * Yukseklik;
        }

        public double CevreHesapla()
        {
            return (Genislik + Yukseklik) * 2; 
        }
    }

    class Program
    {
        static void Main()
        {
            Rect r1 = new Rect(12,13);
            Console.WriteLine($"Alan: {r1.AlanHesapla()}");
            Console.WriteLine($"Cevre: {r1.CevreHesapla()}");
        }
    }

}




