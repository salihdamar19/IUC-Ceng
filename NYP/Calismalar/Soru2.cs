using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Soru2
{
    class Kitap
    {
        string Title;
        string Author;
        int Page;

        public Kitap()
        {
            Title = "Bilinmiyor";
            Author = "Bilinmiyor";
            Page = 0;
        }

        public Kitap(string title, string author, int page)
        {
            Title = title;
            Author = author;
            Page = page;
        }

        public Kitap(string title, string author) 
            : this(title, author, 123)
        {    
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Kitap Adi: {Title}\nYazar: {Author}\nSayfa Sayisi: {Page}");
        }
    }

    class Program
    {
        static void Main()
        {
            Kitap k1 = new Kitap();
            Kitap k2 = new Kitap("Kuyucakli Yusuf", "Sabahattin Ali", 220);
            Kitap k3 = k2;

            k1.ShowInfo();
            Console.WriteLine();
            k2.ShowInfo();
            Console.WriteLine();
            k3.ShowInfo();
        }
    }
}
/*
Kitap sınıfına üç farklı constructor ekleyin: parametresiz, sadece başlık alan, başlık + yazar + sayfa alan. Kod tekrarını
this() zincirlemesiyle önleyin.
*/