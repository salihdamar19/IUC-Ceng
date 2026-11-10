// siparis hesapla
double h(double f, int a)
{
    if (f > 0)
    {
        if (a > 0)
        {
            double s = f * a;
            if (s > 500)
            {
                s = s - s * 0.1; // indirim
            }
            return s * 1.18; // kdv
        }
    }
    return 0;
}

const double IndirimEsigi = 500;
const double IndirimCarpani = 0.9;
const double KdvCarpani = 1.18;

double IndirimUygula(double sepetTutari)
{
    if(sepetTutari <= IndirimEsigi) return sepetTutari;
    return sepetTutari * IndirimCarpani;
}

double SiparisTutariHesapla(double fiyat, int adet)
{
    if(fiyat <= 0 || adet <= 0) return 0;
    double sepetTutari = IndirimUygula(fiyat * adet) * KdvCarpani;
    return sepetTutari;
}