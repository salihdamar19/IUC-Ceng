using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

interface IKahve
{
    decimal Fiyat();
    string Aciklama();
}

class SadeKahve : IKahve
{
    public decimal Fiyat()
    {
        return 50;
    }

    public string Aciklama()
    {
        return "Sade Kahve";
    }
}

class SutDecorator : IKahve
{
    private IKahve kahve;

    public SutDecorator(IKahve kahve)
    {
        this.kahve = kahve;
    }

    public decimal Fiyat()
    {
        return kahve.Fiyat() + 10;
    }

    public string Aciklama()
    {
        return kahve.Aciklama() + " + sut";
    }
}

class SurupDecorator : IKahve
{
    private IKahve kahve;

    public SurupDecorator(IKahve kahve)
    {
        this.kahve = kahve;
    }

    public decimal Fiyat()
    {
        return kahve.Fiyat() + 15;
    }
    public string Aciklama()
    {
        return kahve.Aciklama() + " + surup";
    }
}

class Program
{
    static void Main()
    {
        IKahve k = new SadeKahve();
        k = new SutDecorator(k);
        k = new SurupDecorator(k);

        Console.WriteLine(k.Aciklama());
        Console.WriteLine(k.Fiyat());
    }
}