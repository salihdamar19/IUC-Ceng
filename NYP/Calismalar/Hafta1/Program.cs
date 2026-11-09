/*
İstenenler:

Alanlar (public): brand (string), model (string), year (int), speed (double)
Start() → Tesla Model 3 çalıştırıldı. biçiminde yazdırır
Accelerate(double increase) → hıza ekler, Hız artırıldı. Yeni hız: X km/h yazdırır
Brake(double decrease) → hızdan çıkarır, hız negatif olamaz (olursa 0 yap), Fren yapıldı. Yeni hız: X km/h yazdırır
ShowInfo() → Marka: …, Model: …, Yıl: …, Anlık Hız: … km/h
Main: Tesla, Model 3, 2022, hız 0. Sırayla: ShowInfo, Start, Accelerate(50), Accelerate(30), Brake(40), ShowInfo
*/
using System;

class Car
{
    public string brand;
    public string model;
    public int year;
    public double speed;

    public void Start()
    {
        Console.WriteLine($"{brand} {model} calistirildi");
    }
        
    public void Accelerate(double increase)
    {
        speed += increase;
        Console.WriteLine($"Hiz arttirildi. Yeni hiz: {speed}km/h");
    }

    public void Brake(double decrease)
    {
        speed -= decrease;
        if(speed < 0) speed = 0;
        Console.WriteLine($"Fren yapıldı. Yeni hız: {speed} km/h");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Marka: {brand} Model: {model} Yil: {year} Hiz: {speed}");
    }


};

class Program
{
    static void Main()
    {
        Car car1 = new Car();
        car1.brand = "Fiat";
        car1.model = "Egea";
        car1.year = 2022;
        car1.speed = 0;

        car1.ShowInfo();
        car1.Start();
        car1.Accelerate(50);
        car1.Accelerate(30);
        car1.Brake(40);
        car1.ShowInfo();
    }

};


