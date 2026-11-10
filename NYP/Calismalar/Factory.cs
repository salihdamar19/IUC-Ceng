using System;

interface IDusman
{
    void Saldir();
}

class Zombi : IDusman
{
    public void Saldir()
    {
        Console.WriteLine("Zombi saldirir.");        
    }
}

class Robot : IDusman
{
    public void Saldir()
    {
        Console.WriteLine("Robot saldirir.");
    }
}

class Uzayli : IDusman
{
    public void Saldir()
    {
        Console.WriteLine("Uzayli saldirir.");
    }
}

abstract class DusmanFabrikasi
{
    public abstract IDusman DusmanYarat();
}

class KolayFabrika : DusmanFabrikasi
{
    public override IDusman DusmanYarat()
    {
        return new Zombi();
    }
}

class OrtaFabrika : DusmanFabrikasi
{
    public override IDusman DusmanYarat()
    {
        return new Robot();
    }
}

class ZorFabrika : DusmanFabrikasi
{
    public override IDusman DusmanYarat()
    {   
        return new Uzayli();
    }
}

class Program
{
    static void Main()
    {
        DusmanFabrikasi f = new OrtaFabrika();
        IDusman d = f.DusmanYarat();
        d.Saldir();
        DusmanFabrikasi f2 = new ZorFabrika();
        IDusman d2 = f2.DusmanYarat();
        d2.Saldir();
    }
}
/*
Yönerge:

IDusman interface’i: void Saldir()
Zombi, Robot, Uzayli sınıfları IDusman’ı uygular. Saldır ekrana "Zombi saldırır", "Robot saldırır", "Uzaylı saldırır" yazar.
abstract class DusmanFabrikasi: public abstract IDusman DusmanYarat();
KolayFabrika (Zombi döndürür), OrtaFabrika (Robot döndürür), ZorFabrika (Uzayli döndürür). Hepsi DusmanFabrikasi’ndan türer.
Main:
DusmanFabrikasi f = new OrtaFabrika();
IDusman d = f.DusmanYarat();
d.Saldir();
sonra f = new ZorFabrika(); ile aynısını tekrarla
*/