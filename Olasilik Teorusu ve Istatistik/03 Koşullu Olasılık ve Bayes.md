# Koşullu Olasılık, Toplam Olasılık ve Bayes (Bölüm 4.3–4.5)

Vize planı: [[00 Vize Planı]] · Önceki: [[02 Temel Olasılık Kuralları]]

## 1. Koşullu olasılık
"B olduğunu biliyorum, A olma olasılığı ne?" Dünyayı B'ye daraltırsın:

$$P(A\mid B)=\frac{P(A\cap B)}{P(B)}$$

**Çarpma kuralı** (yatay ağaçta dalları çarp):

$$P(A\cap B)=P(B)\,P(A\mid B)$$

Bağımsızsa $P(A\mid B)=P(A)$.

## 2. Toplam olasılık
Evren birbirini dışlayan parçalara ($A_1, A_2, \dots$) ayrılıyorsa:

$$P(H)=P(A_1)P(H\mid A_1)+P(A_2)P(H\mid A_2)+\dots$$

## 3. Bayes
Sonuç belli (ör. ürün hatalı), "hangi koldan geldi?" sorusu:

$$P(A_i\mid H)=\frac{P(A_i)\,P(H\mid A_i)}{P(H)}$$

**Bayes = bir dal ÷ tüm dalların toplamı.**

## Tarif (her Bayes sorusunda aynı)
1. Olayları adlandır (A = saldırı, T = test pozitif).
2. Verilenleri yaz: $P(A)$, $P(T\mid A)$, $P(T\mid A')$.
3. Paydayı bul: $P(T)=P(A)P(T\mid A)+P(A')P(T\mid A')$.
4. Bayes: $P(A\mid T)=\dfrac{P(A)P(T\mid A)}{P(T)}$.

**Dikkat:** $P(T\mid A)\ne P(A\mid T)$. Yer değiştirme.

## Örnek
Kargo paketlerinin %70'ini A, %30'unu B kuryesi taşıyor. A'nın %2'si, B'nin %10'u hasarlı. Hasarlı paket B'den geldi mi?

- $P(H)=0{,}7\cdot0{,}02+0{,}3\cdot0{,}10=0{,}044$
- $P(B\mid H)=\dfrac{0{,}030}{0{,}044}\approx 0{,}68$

## Alıştırma (cevapsız)
Hocanın 2. hafta ödevi, 5. soru:
Genetik özellik nüfusun %0,8'inde var. Test, olanların %99'unu buluyor, olmayanların %1'ine yanlış pozitif diyor. Test pozitif çıktı. Gerçekten özelliğe sahip olma olasılığı?

> Önce içgüdünle bir sayı yaz, sonra tarifle çöz.
