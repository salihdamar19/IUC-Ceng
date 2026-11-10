/*

1. KargoDurumu isimli bir enum oluşturunuz. Olusturuldu, Yolda, TeslimEdildi ve IptalEdildi değerlerini içersin.

2. ITakipEdilebilir isimli bir interface oluşturunuz. Kargo durumunu değiştirmek için DurumGuncelle() metodunu içersin.

3. Kargo isimli bir abstract class oluşturunuz.

4. Her kargonun TakipNumarasi, MusteriAdi, Agirlik ve Durum bilgileri olsun.

5. TakipNumarasi dışarıdan okunabilsin ancak sonradan değiştirilemesin.

6. Agirlik değeri 0 veya negatif olamasın. Böyle bir değer verilirse ArgumentException oluşturulsun.

7. Kargo sınıfı içerisinde UcretHesapla() isimli abstract bir metot tanımlansın.

8. YurticiKargo ve UluslararasiKargo sınıfları Kargo sınıfından türetilsin.

9. Yurt içi kargo ücreti:
    
    100 + Agirlik × 15
    
    formülüyle hesaplanmalıdır.

    Uluslararası kargo ücreti ise:
    
    250 + Agirlik × 40 + GumrukUcreti
    
    formülüyle hesaplanmalıdır.

10. BilgileriGoster() metodu Kargo sınıfında virtual olarak tanımlansın ve alt sınıflarda override edilerek özelleştirilsin.

11. Farklı kargo nesneleri List<Kargo> içerisinde saklansın ve foreach ile bilgileri gösterilerek polymorphism kullanımı sağlansın.

12. Kargo durumları ITakipEdilebilir interface'i üzerinden değiştirilebilsin.

13. Teslim edilmiş veya iptal edilmiş bir kargonun durumu tekrar değiştirilmeye çalışılırsa InvalidOperationException oluşturulsun.

14. Program içerisinde try-catch-finally kullanılarak oluşabilecek hatalar kontrollü şekilde yönetilsin.

*/

using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

enum KargoDurumu
{
    Olusturuldu,
    Yolda,
    TeslimEdildi,
    IptalEdildi
}

interface ITakipEdilebilir
{
    KargoDurumu Durum {get;}
    void DurumGuncelle(KargoDurumu yeniDurum);
}

abstract class Kargo : ITakipEdilebilir
{
    public string TakipNumarasi {get;}
    public string MusteriAdi {get; set;}
    public double Agirlik {get;}
    public KargoDurumu Durum {get; private set;}

    public Kargo(string takipNumarasi, string musteriAdi, double agirlik)
    {
        TakipNumarasi = takipNumarasi;
        MusteriAdi = musteriAdi;
        if(agirlik <= 0)
        {
            throw new ArgumentException("Agirlik sifirdan buyuk olmali.");
        }
        Agirlik = agirlik;
    }

    public void DurumGuncelle(KargoDurumu yeniDurum)
    {
        if(Durum == KargoDurumu.TeslimEdildi || Durum == KargoDurumu.IptalEdildi)
        {
            throw new InvalidOperationException("Teslim/Iptal isleminden sonra kargo durumu degistirilemez.");
        }
        Durum = yeniDurum;
    }

    public virtual void BilgileriGoster()
    {
        Console.WriteLine($"Takip Numarasi: {TakipNumarasi}\nMusteri Adi: {MusteriAdi}");
    }

    public abstract decimal UcretHesapla();

    
}

class YurticiKargo : Kargo
{
    public YurticiKargo(string takipNumarasi, string musteriAdi, double agirlik)
        : base(takipNumarasi, musteriAdi, agirlik)
    {
    }

    public override decimal UcretHesapla()
    {
        return 100 + (decimal)Agirlik * 15;
    }

    public override void BilgileriGoster()
    {
        Console.WriteLine($"Takip Numarasi: {TakipNumarasi}\nMusteri Adi: {MusteriAdi}\nKargo Turu: Yurtici Kargo\nAgirlik:{Agirlik}\nUcret:{UcretHesapla()}\nDurum: {Durum}");
    }
}

class UluslararasiKargo : Kargo
{
    public decimal GumrukUcreti{get; private set;}

    public UluslararasiKargo(string takipNumarasi, string musteriAdi, double agirlik, decimal gumrukUcreti)
        : base(takipNumarasi, musteriAdi, agirlik)
    {
        GumrukUcreti = gumrukUcreti;
    }

    public override decimal UcretHesapla()
    {
        return 250 + (decimal)Agirlik * 40 + GumrukUcreti;
    }

    public override void BilgileriGoster()
    {
        Console.WriteLine($"Takip Numarasi: {TakipNumarasi}\nMusteri Adi: {MusteriAdi}\nKargo Turu: Uluslararasi Kargo\nAgirlik:{Agirlik}\nUcret:{UcretHesapla()}\nDurum: {Durum}");        
    }

}
class Program
{
    static void Main()
    {
        List<Kargo> teslimatlar = new List<Kargo>();

        try
        {
            YurticiKargo yurtici = new YurticiKargo("123123", "Salih Damar", 2.5);
            teslimatlar.Add(yurtici);


            UluslararasiKargo uluslararasi = new UluslararasiKargo("12332", "Salih Demir", 2.7, 300);
            teslimatlar.Add(uluslararasi);

            foreach(var kargo in teslimatlar)
            {
                kargo.BilgileriGoster();
            }

            ITakipEdilebilir takip = yurtici;
            takip.DurumGuncelle(KargoDurumu.Yolda);
            yurtici.BilgileriGoster();
            takip.DurumGuncelle(KargoDurumu.TeslimEdildi);
            yurtici.BilgileriGoster();
            takip.DurumGuncelle(KargoDurumu.Yolda);
            yurtici.BilgileriGoster();

            YurticiKargo yurtici1 = new YurticiKargo("TR-12312", "Salih Damar", -1);
            teslimatlar.Add(yurtici1);
        }

        catch(ArgumentException hata)
        {
            Console.WriteLine();
            Console.WriteLine("VERI HATASI:");
            Console.WriteLine(hata.Message);
        }
        
        catch(InvalidOperationException hata)
        {
            Console.WriteLine();
            Console.Write("ISLEM HATASI:");
            Console.Write(hata.Message);
        }

        catch(Exception hata)
        {
            Console.WriteLine();
            Console.WriteLine("BEKLENMEYEN HATA:");
            Console.WriteLine(hata.Message);
        }



        finally
        {
            Console.WriteLine("\nProgram basariyla sonlandi.");
        }
    }
}