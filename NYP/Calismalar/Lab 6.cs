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
using System.Collections.Generic;


// ENUM

// Bir kargonun sahip olabileceği durumları tanımlıyoruz.
enum KargoDurumu
{
    Olusturuldu,
    Yolda,
    TeslimEdildi,
    IptalEdildi
}


// INTERFACE

// Takip edilebilir nesnelerin sahip olması gereken
// özellik ve davranışları tanımlıyoruz.
interface ITakipEdilebilir
{
    KargoDurumu Durum { get; }

    void DurumGuncelle(KargoDurumu yeniDurum);
}


// ABSTRACT BASE CLASS

// Kargo genel bir kavramdır.
//
// Doğrudan Kargo nesnesi oluşturmak istemiyoruz.
// Kargonun YurticiKargo veya UluslararasiKargo
// türlerinden biri olmasını istiyoruz.
//
// Bu nedenle abstract class kullanıyoruz.
abstract class Kargo : ITakipEdilebilir
{

    // PRIVATE FIELDS

    private string musteriAdi;
    private double agirlik;


    // PROPERTIES

    // Takip numarası dışarıdan okunabilir,
    // ancak dışarıdan değiştirilemez.
    public string TakipNumarasi { get; private set; }


    // Müşteri adına kontrollü erişim sağlıyoruz.
    public string MusteriAdi
    {
        get
        {
            return musteriAdi;
        }

        set
        {
            // Müşteri adı boş bırakılamaz.
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Musteri adi bos olamaz."
                );
            }

            musteriAdi = value;
        }
    }


    // Ağırlığa kontrollü erişim sağlıyoruz.
    public double Agirlik
    {
        get
        {
            return agirlik;
        }

        set
        {
            // Ağırlık 0 veya negatif olamaz.
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Agirlik sifirdan buyuk olmalidir."
                );
            }

            agirlik = value;
        }
    }


    // Durum dışarıdan okunabilir.
    //
    // private set sayesinde dışarıdan:
    //
    // kargo.Durum = ...
    //
    // şeklinde doğrudan değiştirilemez.
    public KargoDurumu Durum { get; private set; }


    // CONSTRUCTOR

    // Kargo abstract olduğu için constructor protected tanımlandı.
    // Bu constructor alt sınıflar tarafından kullanılacaktır.
    protected Kargo(
        string takipNumarasi,
        string musteriAdi,
        double agirlik)
    {
        // Takip numarası boş bırakılamaz.
        if (string.IsNullOrWhiteSpace(takipNumarasi))
        {
            throw new ArgumentException(
                "Takip numarasi bos olamaz."
            );
        }


        TakipNumarasi = takipNumarasi;


        // Property üzerinden atama yapıyoruz.
        //
        // Böylece property içerisindeki validation
        // kontrolleri de çalışacaktır.
        MusteriAdi = musteriAdi;

        Agirlik = agirlik;


        // Yeni oluşturulan her kargonun
        // başlangıç durumu Olusturuldu olur.
        Durum = KargoDurumu.Olusturuldu;
    }


    // ABSTRACT METHOD

    // Her kargonun bir taşıma ücreti vardır.
    //
    // Ancak ücret hesaplama yöntemi kargo türüne
    // göre farklı olduğu için burada implementation yazmıyoruz.
    //
    // Alt sınıflar bu methodu override etmek zorundadır.
    public abstract decimal UcretHesapla();


    // VIRTUAL METHOD

    // Kargonun ortak bilgilerini ekrana yazdırır.
    //
    // virtual olduğu için alt sınıflar
    // bu methodu override edebilir.
    public virtual void BilgileriGoster()
    {
        Console.WriteLine(
            $"Takip Numarasi : {TakipNumarasi}"
        );

        Console.WriteLine(
            $"Musteri        : {MusteriAdi}"
        );

        Console.WriteLine(
            $"Agirlik        : {Agirlik} kg"
        );

        Console.WriteLine(
            $"Durum          : {Durum}"
        );
    }


    // INTERFACE IMPLEMENTATION

    // ITakipEdilebilir interface'i içerisindeki
    // DurumGuncelle methodunu gerçekleştiriyoruz.
    public void DurumGuncelle(KargoDurumu yeniDurum)
    {
        // Teslim edilmiş bir kargonun durumu
        // tekrar değiştirilemez.
        if (Durum == KargoDurumu.TeslimEdildi)
        {
            throw new InvalidOperationException(
                "Teslim edilen kargonun durumu degistirilemez."
            );
        }


        // İptal edilmiş bir kargonun durumu
        // tekrar değiştirilemez.
        if (Durum == KargoDurumu.IptalEdildi)
        {
            throw new InvalidOperationException(
                "Iptal edilen kargonun durumu degistirilemez."
            );
        }


        // Kontroller başarılıysa yeni durum atanır.
        Durum = yeniDurum;
    }
}


// YURT İÇİ KARGO

// YurticiKargo bir Kargo'dur.
//
// YurticiKargo IS-A Kargo
//
// Burada inheritance kullanıyoruz.
class YurticiKargo : Kargo
{
    public string Sehir { get; set; }


    // Constructor
    public YurticiKargo(
        string takipNumarasi,
        string musteriAdi,
        double agirlik,
        string sehir)
        : base(
            takipNumarasi,
            musteriAdi,
            agirlik)
    {
        Sehir = sehir;
    }


    // Kargo sınıfındaki abstract methodu
    // gerçekleştirmek zorundayız.
    public override decimal UcretHesapla()
    {
        // Yurt içi kargo:
        //
        // 100 TL sabit ücret
        // +
        // kilogram başına 15 TL

        return 100 + (decimal)Agirlik * 15;
    }


    // BilgileriGoster methodunu
    // YurticiKargo için özelleştiriyoruz.
    public override void BilgileriGoster()
    {
        Console.WriteLine(
            "===== YURT ICI KARGO ====="
        );


        // Base class içerisindeki ortak bilgileri gösteriyoruz.
        base.BilgileriGoster();


        Console.WriteLine(
            $"Sehir          : {Sehir}"
        );


        Console.WriteLine(
            $"Kargo Ucreti   : {UcretHesapla()} TL"
        );
    }
}


// ULUSLARARASI KARGO

class UluslararasiKargo : Kargo
{
    public string Ulke { get; set; }


    // Gümrük ücreti dışarıdan okunabilir
    // ancak doğrudan değiştirilemez.
    public decimal GumrukUcreti { get; private set; }


    // Constructor
    public UluslararasiKargo(
        string takipNumarasi,
        string musteriAdi,
        double agirlik,
        string ulke,
        decimal gumrukUcreti)
        : base(
            takipNumarasi,
            musteriAdi,
            agirlik)
    {
        // Gümrük ücreti negatif olamaz.
        if (gumrukUcreti < 0)
        {
            throw new ArgumentException(
                "Gumruk ucreti negatif olamaz."
            );
        }


        Ulke = ulke;

        GumrukUcreti = gumrukUcreti;
    }


    // Uluslararası kargo ücret hesaplaması.
    public override decimal UcretHesapla()
    {
        // Uluslararası kargo:
        //
        // 250 TL sabit ücret
        // +
        // kilogram başına 40 TL
        // +
        // gümrük ücreti

        return 250
               + (decimal)Agirlik * 40
               + GumrukUcreti;
    }


    public override void BilgileriGoster()
    {
        Console.WriteLine(
            "===== ULUSLARARASI KARGO ====="
        );


        base.BilgileriGoster();


        Console.WriteLine(
            $"Ulke           : {Ulke}"
        );


        Console.WriteLine(
            $"Gumruk Ucreti  : {GumrukUcreti} TL"
        );


        Console.WriteLine(
            $"Kargo Ucreti   : {UcretHesapla()} TL"
        );
    }
}


// PROGRAM

class Program
{
    static void Main()
    {
        try
        {
            
            // OBJECT CREATION

            // Yurt içi kargo nesnesi oluşturuyoruz.
            YurticiKargo kargo1 =
                new YurticiKargo(
                    "TR1001",
                    "Ahmet Yilmaz",
                    10,
                    "Ankara"
                );


            // Uluslararası kargo nesnesi oluşturuyoruz.
            UluslararasiKargo kargo2 =
                new UluslararasiKargo(
                    "INT2001",
                    "Ayse Kaya",
                    5,
                    "Almanya",
                    300
                );


            // İkinci yurt içi kargo nesnesi.
            YurticiKargo kargo3 =
                new YurticiKargo(
                    "TR1002",
                    "Mehmet Demir",
                    20,
                    "Istanbul"
                );


            
            // POLYMORPHISM
            
            // Listenin türü Kargo.
            //
            // Ancak hem YurticiKargo hem de
            // UluslararasiKargo nesnelerini
            // aynı liste içerisinde tutabiliyoruz.
            List<Kargo> kargolar =
                new List<Kargo>();


            kargolar.Add(kargo1);

            kargolar.Add(kargo2);

            kargolar.Add(kargo3);


            Console.WriteLine(
                "===== TUM KARGOLAR ====="
            );


           
            // POLYMORPHISM
            

            foreach (Kargo kargo in kargolar)
            {
                // kargo değişkeninin tipi Kargo'dur.
                //
                // Ancak gerçek nesne:
                //
                // YurticiKargo ise
                // YurticiKargo.BilgileriGoster()
                //
                // UluslararasiKargo ise
                // UluslararasiKargo.BilgileriGoster()
                //
                // çalışacaktır.

                kargo.BilgileriGoster();

                Console.WriteLine();
            }


           
            // INTERFACE KULLANIMI

            Console.WriteLine(
                "===== DURUM GUNCELLEME ====="
            );


            // kargo1 gerçekte YurticiKargo nesnesidir.
            //
            // Ancak ITakipEdilebilir interface'i üzerinden
            // de referans verebiliriz.
            ITakipEdilebilir takipEdilebilirKargo =
                kargo1;


            // Interface içerisindeki methodu kullanıyoruz.
            takipEdilebilirKargo.DurumGuncelle(
                KargoDurumu.Yolda
            );


            Console.WriteLine(
                $"{kargo1.TakipNumarasi} durum: " +
                $"{kargo1.Durum}"
            );


            
            // BAŞKA BİR KARGONUN DURUMUNU DEĞİŞTİRME

            // Uluslararası kargoyu önce yola çıkarıyoruz.
            kargo2.DurumGuncelle(
                KargoDurumu.Yolda
            );


            // Ardından teslim ediyoruz.
            kargo2.DurumGuncelle(
                KargoDurumu.TeslimEdildi
            );


            Console.WriteLine(
                $"{kargo2.TakipNumarasi} durum: " +
                $"{kargo2.Durum}"
            );


            
            // EXCEPTION TEST
            
            Console.WriteLine();

            Console.WriteLine(
                "===== GECERSIZ ISLEM TESTI ====="
            );


            // kargo2 zaten TeslimEdildi durumunda.
            //
            // Tekrar Yolda durumuna getirmeye çalışıyoruz.
            //
            // DurumGuncelle içerisinde:
            //
            // throw new InvalidOperationException(...)
            //
            // çalışacaktır.
            kargo2.DurumGuncelle(
                KargoDurumu.Yolda
            );


            // Exception oluştuğu için
            // bu satır çalışmayacaktır.
            Console.WriteLine(
                "Bu satir calismayacak."
            );
        }


        
        // ARGUMENT EXCEPTION

        // Geçersiz müşteri adı, ağırlık veya
        // gümrük ücreti verilirse burası çalışır.
        catch (ArgumentException hata)
        {
            Console.WriteLine();

            Console.WriteLine(
                "VERI HATASI:"
            );

            Console.WriteLine(
                hata.Message
            );
        }


        // INVALID OPERATION EXCEPTION

        // Kargonun mevcut durumuna uygun olmayan
        // bir işlem yapılırsa burası çalışır.
        catch (InvalidOperationException hata)
        {
            Console.WriteLine();

            Console.WriteLine(
                "ISLEM HATASI:"
            );

            Console.WriteLine(
                hata.Message
            );
        }


        // GENERAL EXCEPTION

        // Beklenmeyen başka bir exception oluşursa
        // genel Exception tarafından yakalanır.
        catch (Exception hata)
        {
            Console.WriteLine();

            Console.WriteLine(
                "BEKLENMEYEN HATA:"
            );

            Console.WriteLine(
                hata.Message
            );
        }


        // FINALLY

        // Exception oluşsa da oluşmasa da çalışır.
        finally
        {
            Console.WriteLine();

            Console.WriteLine(
                "Program sona erdi."
            );
        }
    }
}
