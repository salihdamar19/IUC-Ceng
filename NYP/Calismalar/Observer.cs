using System;
using System.Diagnostics.Contracts;
using System.Numerics;

interface IAbone
{
    void Bildir(string mesaj);
}

class SmsAbone : IAbone
{
    public void Bildir(string mesaj)
    {
        Console.WriteLine($"SMS: {mesaj}");
    }
}

class EmailAbone : IAbone
{
    public void Bildir(string mesaj)
    {
        Console.WriteLine($"Email: {mesaj}");
    }
}

class Kargo
{
    private string Durum = "Hazirlaniyor.";
    private List<IAbone> aboneler = new List<IAbone>();

    public void AboneOl(IAbone a) {aboneler.Add(a);}

    public void AbonelikSil(IAbone a) {aboneler.Remove(a);}

    public void DurumBildir()
    {
        foreach(var abone in aboneler)
        {
            abone.Bildir($"Kargo Durumu: {Durum}");
        }
    }

    public void DurumGuncelle(string yeniDurum)
    {
        Durum = yeniDurum;
        foreach(var abone in aboneler)
        {
            abone.Bildir($"Kargo durumu: {Durum}");
        }
    }


} 

class Program
{
    
    static void Main()
    {
        Kargo k1 = new Kargo();

        SmsAbone sms = new SmsAbone();
        k1.AboneOl(sms);

        EmailAbone email = new EmailAbone();
        k1.AboneOl(email);

        k1.DurumGuncelle("Yolda");

        k1.AbonelikSil(email);

        k1.DurumGuncelle("Teslim edildi");
    }
    
}
/*
Görev 1: Observer (vaka)

Bir kargo firması, kargonun durumu değişince müşteriyi bilgilendirmek istiyor.

Yönerge:

IAbone interface’i: void Bildir(string mesaj)
SmsAbone ve EmailAbone sınıfları IAbone’yi uygular. Konsola "SMS: ..." ve "Email: ..." yazdırır.
Kargo sınıfı:
içinde List<IAbone> tutar
AboneOl(IAbone a) ve AbonelikSil(IAbone a) metotları
DurumGuncelle(string yeniDurum): durumu değiştirir, tüm abonelere "Kargo durumu: <yeniDurum>" mesajını gönderir
Main:
bir Kargo yarat
SmsAbone ve EmailAbone ekle
DurumGuncelle("Yolda") çağır
EmailAbone’u sil
DurumGuncelle("Teslim edildi") çağır
*/