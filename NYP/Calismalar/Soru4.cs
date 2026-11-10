using System;
//4. Sayac adında bir sınıf yazın. Kaç adet Sayac nesnesi oluşturulduğunu static bir sayaçla takip etsin.
namespace Soru4
{
    class Sayac
    {
        string Ad{get;}
        public static int ToplamSayacSayisi {get; private set;}

        static Sayac(){
            ToplamSayacSayisi = 0;
        }

        public Sayac()
        {
            Ad = "Bilinmiyor";
            ToplamSayacSayisi++;
        }
        public Sayac(string ad)
        {
            Ad = string.IsNullOrWhiteSpace(ad) ? ad : "";
            ToplamSayacSayisi++;
        }

    }

    class Program
    {
        static void Main()
        {
            Sayac s1 = new Sayac();
            Sayac s2 = new Sayac("asda");
            Console.WriteLine(Sayac.ToplamSayacSayisi);
        }
    }
}