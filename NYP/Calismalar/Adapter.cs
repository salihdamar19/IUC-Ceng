using System;

interface IHavaDurumu
{
    double SicaklikCelsius(string sehir);
}

class EskiHavaServisi
{
    public string SicaklikFahrenheit(string sehir)
    {
        return "72.5F";
    }
}

class EskiServisAdapter : IHavaDurumu
{
    private EskiHavaServisi eski = new EskiHavaServisi();

    public double SicaklikCelsius(string sehir)
    {
        string s = eski.SicaklikFahrenheit(sehir);
        s = s.Replace("F","");
        double f = double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        return (f - 32) * 5 / 9;
    }
}

class Program
{
    static void Main()
    {
        IHavaDurumu h = new EskiServisAdapter();
        Console.WriteLine(h.SicaklikCelsius("Istanbul"));
    }
}
/*
Görev 4: Adapter (hava durumu)

Senin uygulaman Celsius istiyor, eski servis Fahrenheit veriyor ve onu değiştiremiyorsun.

Yönerge:

IHavaDurumu interface’i: double SicaklikCelsius(string sehir)
Eski servis (kodunu “değiştirilemez” say, hiç dokunma):
csharp
class EskiHavaServisi
{
    public string SicaklikFahrenheit(string sehir)
    {
        return "72.5F";
    }
}
EskiServisAdapter : IHavaDurumu:
içinde bir EskiHavaServisi tutar (alan olarak, new ile veya constructor’dan)
SicaklikCelsius(string sehir): eski servisten "72.5F" stringini alır, sondaki F harfini silip sayıya çevirir, Celsius’a dönüştürür ve döndürür
Main: IHavaDurumu h = new EskiServisAdapter(); oluştur, h.SicaklikCelsius("Istanbul") sonucunu yazdır.

Formül: C = (F - 32) * 5 / 9

Beklenen çıktı: 22,5 (72.5°F = 22.5°C, ondalık işareti bilgisayarına göre nokta ya da virgül olabilir)

İpuçları:

"72.5F"’den F’yi silmek: s.Replace("F", "")
String’i sayıya çevirmek: double.Parse(...). Noktalı sayıda hata verirse double.Parse(x, System.Globalization.CultureInfo.InvariantCulture) kullan (Türkçe ayarlarda nokta sorun çıkarabilir).
IHavaDurumu h tipinde yaz, EskiServisAdapter h değil. İstemci adapter’ı değil interface’i bilmeli.

Kural: EskiHavaServisi sınıfına dokunma. Adapter’ın tüm işi onu çevirmek.
*/