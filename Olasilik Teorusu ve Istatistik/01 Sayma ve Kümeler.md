# Sayma ve Kümeler (Bölüm 2–3)

Vize planı: [[00 Vize Planı]]

## Kümeler ve örnek uzay
- **Örnek uzay S:** deneyin tüm olası sonuçları. 3 para atışı: $|S| = 2^3 = 8$
- **Olay:** S'nin alt kümesi (ör. "en az 2 tura")
- $A\cup B$ (A veya B), $A\cap B$ (ikisi birden), $A'$ (A olmayan)
- **De Morgan:** $(A\cup B)' = A'\cap B'$ ve $(A\cap B)' = A'\cup B'$
- Eşit olasılıklı sonuçlarda: $P(A) = \dfrac{|A|}{|S|}$

## Temel sayma kuralı
Birbirini izleyen seçimlerde seçenek sayılarını **çarp**.

Örnek: plaka 2 harf + 3 rakam, tekrarlı: $29\cdot 29\cdot 10\cdot 10\cdot 10$

## Permütasyon mu, kombinasyon mu?
**Kısa test:** "Aynı kişiler farklı sırada seçilirse farklı sonuç sayılır mı?" Evetse permütasyon, hayırsa kombinasyon.

| Durum | Formül | Örnek |
|---|---|---|
| **Sıra önemli** (başkan, yardımcı, sekreter) | $P(n,r)=\dfrac{n!}{(n-r)!}$ | 10 kişiden 3 görev: $10\cdot 9\cdot 8 = 720$ |
| **Sıra önemsiz** (komite) | $C(n,r)=\dbinom{n}{r}=\dfrac{n!}{r!\,(n-r)!}$ | 10 kişiden 3 kişilik komite: $120$ |
| **Tekrar eden harfli sıralama** | $\dfrac{n!}{n_1!\,n_2!\cdots}$ | MATEMATİK: $\dfrac{9!}{2!\,2!\,2!}=45360$ |

## Diğer formüller (Bölüm 3)
- **Tekrarlı kombinasyon:** n çeşitten r tane seç (tekrar serbest): $\dbinom{n+r-1}{r}$
- **Sıralı parçalanma:** n kişiyi $n_1, n_2, \dots$ kişilik gruplara: $\dfrac{n!}{n_1!\,n_2!\cdots}$
- **Binom teoremi:** $(a+b)^n=\sum_{k=0}^n \dbinom{n}{k}a^{n-k}b^k$

## Alıştırma (cevapsız)
1. 8 kişilik kulüpten 3 kişilik komite: kaç farklı komite?
	56
2. 7 erkek, 5 kadından 4 kişilik komite, en az 2 kadın şartıyla?
	
3. "İSTATİSTİK" harfleriyle kaç farklı 10 harfli kelime?
4. $(2x-1)^6$ açılımında $x^4$ katsayısı?
