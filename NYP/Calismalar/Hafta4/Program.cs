using System;

class Program
{
    static void Main()
    {
        
    }
}

/*
Senaryo
Bir kütüphanede kitap, DVD ve yalnızca kütüphane içinde kullanılabilen referans kitapları bulunmaktadır.
Bütün materyallerin ortak özellikleri vardır; ancak yalnızca bazı materyaller ödünç alınabilir. 
Kitaplar 14 gün, DVD’ler 7 gün ödünç verilebilir. Referans kitapları ise dışarı çıkarılamaz.

Görevler
1. LibraryMaterial isimli bir abstract sınıf oluşturunuz.
2. LibraryMaterial sınıfına aşağıdaki property’leri ekleyiniz:
   - Id
   - Title
3. Bu property’leri alan bir constructor yazınız.
4. LibraryMaterial sınıfında materyal türünü döndürecek aşağıdaki abstract metodu tanımlayınız:
    
    public abstract string GetMaterialType();
    
6. LibraryMaterial sınıfına materyal bilgilerini ekrana yazdıran çalışan bir DisplayInfo() metodu ekleyiniz.
7. Ödünç alınabilen materyalleri temsil etmek üzere IBorrowable isimli bir interface oluşturunuz.
8. Interface içerisinde aşağıdaki üyeleri tanımlayınız:
   - IsBorrowed
   - LoanPeriodDays
   - DueDate
   - Borrow()
   - Return()
   
9. Book sınıfını oluşturunuz.
   - LibraryMaterial sınıfından kalıtım almalıdır.
   - IBorrowable interface’ini uygulamalıdır.
   - Ödünç alma süresi 14 gün olmalıdır.
   - Zaten ödünç alınmışsa tekrar ödünç verilmemelidir.
10. Dvd sınıfını oluşturunuz.
    - LibraryMaterial sınıfından kalıtım almalıdır.
    - IBorrowable interface’ini uygulamalıdır.
    - Ödünç alma süresi 7 gün olmalıdır.
11. ReferenceBook sınıfını oluşturunuz.
    - LibraryMaterial sınıfından kalıtım almalıdır.
    - IBorrowable interface’ini uygulamamalıdır.
    - Bu nedenle ödünç alınamamalıdır.
    
12. Program.cs içerisinde bütün materyalleri bir List<LibraryMaterial> koleksiyonunda tutunuz.
13. Döngü kullanarak bütün materyallerin bilgilerini ekrana yazdırınız.
14. Materyalin IBorrowable interface’ini uygulayıp uygulamadığını kontrol ediniz.
15. Ödünç alınabilen materyalleri ödünç veriniz ve son iade tarihlerini ekrana yazdırınız.
16. Ödünç alınamayan materyaller için aşağıdaki mesajı gösteriniz:
    
        "Bu materyal yalnızca kütüphane içinde kullanılabilir."
  
*/