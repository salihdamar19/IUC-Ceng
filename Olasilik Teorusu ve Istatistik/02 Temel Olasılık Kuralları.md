# Temel Olasılık Kuralları (Bölüm 4.1–4.2)

Vize planı: [[00 Vize Planı]] · Önceki: [[01 Sayma ve Kümeler]] · Sonraki: [[03 Koşullu Olasılık ve Bayes]]

## Aksiyomlar
- $0\le P(A)\le 1$
- $P(S)=1$
- Ayrık olaylarda ($A\cap B=\varnothing$): $P(A\cup B)=P(A)+P(B)$

## Kurallar
- **Tümleyen:** $P(A')=1-P(A)$
- **Toplama:** $P(A\cup B)=P(A)+P(B)-P(A\cap B)$ (kesişimi iki kez saymamak için çıkarılır)
- **Bağımsızlık:** $P(A\cap B)=P(A)\,P(B)$ ise A ve B bağımsızdır
- **De Morgan ile:** $P(A'\cap B') = 1-P(A\cup B)$

## Örnek
$P(A)=0{,}5$, $P(B)=0{,}4$, $P(A\cap B)=0{,}2$
- $P(A\cup B)=0{,}5+0{,}4-0{,}2=0{,}7$
- $P(A'\cap B')=1-0{,}7=0{,}3$
- Bağımsız mı? $P(A)P(B)=0{,}2=P(A\cap B)$ → **evet**

## Alıştırma (cevapsız)
Yukarıdaki değerleri kendin hesapla, sonra $P(A\cap B')$ ve "A ve B ayrık mı?" sorularını yanıtla.
