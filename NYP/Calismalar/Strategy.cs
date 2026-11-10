using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Principal;
using Microsoft.VisualBasic.FileIO;

interface IIndirim
{
    decimal Uygula(decimal fiyat);
}

class OgrenciIndirimi : IIndirim
{
    public decimal Uygula(decimal fiyat)
    {
        return fiyat * 0.80m;
    }
}

class KampanyaIndirimi : IIndirim
{
    public decimal Uygula(decimal fiyat)
    {
        return fiyat * 0.90m;
    }
}

class SadakatIndirimi : IIndirim
{
    public decimal Uygula(decimal fiyat)
    {
        return fiyat * 0.85m;
    }
}

class Sepet
{
    private IIndirim indirim;
    
    public Sepet(IIndirim i)
    {
        indirim = i;
    }

    public decimal ToplamHesapla(decimal fiyat)
    {
        return indirim.Uygula(fiyat);
    }
}

class Program
{
    static void Main()
    {
        int fiyat = 200;
        Sepet s1 = new Sepet(new KampanyaIndirimi());
        Sepet s2 = new Sepet(new OgrenciIndirimi());
        Sepet s3 = new Sepet(new SadakatIndirimi());


        Console.WriteLine($"Kampanya: {s1.ToplamHesapla(fiyat)}");
        Console.WriteLine();

        Console.WriteLine($"Ogrenci: {s2.ToplamHesapla(fiyat)}");
        Console.WriteLine();

        Console.WriteLine($"Sadakat: {s3.ToplamHesapla(fiyat)}");
        Console.WriteLine();
    }
}
/*
Yönerge:

IIndirim interface’i: decimal Uygula(decimal fiyat)
Üç sınıf IIndirim’i uygular:
OgrenciIndirimi: fiyatın %20'sini düşer (yani fiyat * 0.80m)
KampanyaIndirimi: %10 düşer
SadakatIndirimi: %15 düşer
Sepet sınıfı:
içinde bir IIndirim tutar (private IIndirim indirim;)
constructor’ı indirimi dışarıdan alır
ToplamHesapla(decimal fiyat) metodu: indirimi uygulayıp sonucu döndürür
Main: fiyatı 200 al. Üç farklı Sepet yarat (her seferinde farklı indirimle), her birinin sonucunu yazdır.
*/