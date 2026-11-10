using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

interface IButton
{
    void Ciz();
}

interface IFont
{
    void Yaz(string metin);
}

interface IThemeFactory
{
    IButton ButonYarat();
    IFont FontYarat();
}

class DarkButton : IButton
{
    public void Ciz()
    {
        Console.WriteLine("Dark button");
    }
}

class DarkFont : IFont
{
    public void Yaz(string metin)
    {
        Console.WriteLine($"Dark font: {metin}");
    }
}

class LightButton : IButton
{
    public void Ciz()
    {
        Console.WriteLine("Light button");
    }
}

class LightFont : IFont
{
    public void Yaz(string metin)
    {
        Console.WriteLine($"Light font: {metin}");
    }
}

class DarkFactory : IThemeFactory
{
    public IButton ButonYarat()
    {
        return new DarkButton();
    }

    public IFont FontYarat()
    {
        return new DarkFont();
    }
}

class LightFactory : IThemeFactory
{
    public IButton ButonYarat(){
        return new LightButton();
    }

    public IFont FontYarat()
    {
        return new LightFont();
    }

}

class Program
{
    static void Main()
    {
        IThemeFactory f = new DarkFactory();
        IButton b = f.ButonYarat(); IFont t = f.FontYarat();
        b.Ciz(); t.Yaz("Merhaba");

        IThemeFactory f2 = new LightFactory();
        IButton b2 = f2.ButonYarat(); IFont t2 = f2.FontYarat();
        b2.Ciz(); t2.Yaz("Merhaba");
    }
}

/*
Yönerge:

İki ürün interface’i: IButton (void Ciz()) ve IFont (void Yaz(string metin)).
Dark ürünler: DarkButton (Ciz() ekrana "Dark buton" yazar), DarkFont (Yaz(...) ekrana "Dark font: <metin>" yazar).
Light ürünler: LightButton ("Light buton"), LightFont ("Light font: <metin>").
Fabrika interface’i IThemeFactory: IButton ButonYarat() ve IFont FontYarat().
DarkFactory ve LightFactory bu interface’i uygular; her biri kendi temasının buton ve fontunu döndürür.
Main:
IThemeFactory f = new DarkFactory();
IButton b = f.ButonYarat(); IFont t = f.FontYarat();
b.Ciz(); t.Yaz("Merhaba");
sonra f = new LightFactory(); ile aynısını tekrarla
*/