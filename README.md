# move-orders
W tym pliku opisuję wszystkie czynniki jakie uwzględniłem przy tworzeniu mojego rozwiązania. 

## Ważne
* Miałem pewien problem z dokumentacją Baselinkera. Na przykład w dokumentacji metody addOrder parametr wejsciowy order_status_id jest opisany jako typ liczbowy.
Jednakże na tej samej stronie dokumentacji w przykładowym inpucie, ten sam parametr jest przedstawiony w formacie json jako typu tekstowego:
```"order_status_id": "6624"```
Założyłem w tej i podobnych sytuacjach, że dokumentacja jest ważniejsza niż jej przykład użycia i przyjąłem typ (w tym konkretnym wypadku) liczbowy. 

* W przypadku 6 punktu wydaje mi się, że jedynymi niezbędnymi właściwościami są te z 3, 4 i 7 punktu z zadania ze szczególnym naciskiem na ten ostatni, 
ponieważ w polu dodatkowym w baselinkerze podaje id do zamówienia z Faire. Teoretycznie pozwoliłoby to bezpośrednio zidentyfikować adres i co zawiera zamówienie, ale nie jestem całkowicie pewny ze względu na lakoniczność dokumentacji oraz brak możliwości przetestowania rozwiązania, więc dodałem też inne pola, które wydają się odpowiadać za to samo w obu przypadkach (adres, szczegóły produktu itp). Dodatkowo rozwija to też moje rozwiązanie.

## Ograniczenia
Dokumentacja Baselinkera informuje o przepustowości ograniczonej do 100 zapytań na minutę. Może nastąpić sytuacja, że jednorazowo będziemy chcieli dodać więcej niż 100 zamówień.
Jest to dosyć istotna kwestia, ponieważ przy przekroczeniu limitu, możliwośc wykonywania zapytań zostaje zablokowana na 10 min. Cześciowo rozwiązałem ten problem za pomocą możliwośi jakie implementuje klasa TimerInfo, ponieważ po pierwszym wykonaniu funkcji będa pobierane jedynie zamówienia sprzed ostatnich 10 min, więc jest mała szansa na przekroczenie limitu.
Wszystko zależy od tego jak duży jest ruch w sklepie, z którego pobieramy zamówienia.   
W celu całkowitej pewności, że problem ten nie wystąpi, widziałbym kilka możliwych rozwiązań:

* Stworzenie w funkcji służącej do wysyłania zapytań licznika w pętli, który po osiągnięciu danej liczby
(bezpieczniejszą wartościa od 100 była by jakaś liczba około 95, bo w ciągu danej minuty mogły być tez wykonane już przez nas jakieś inne operacje) zatrzyma wykonywanie programu na minutę.
To rozwiązanie jest najbardziej prymitywne i nie jestem jego zwolennikiem.

* Wymuszanie opóźnienia bezpośrednio pomiędzy przesyłaniem zapytań np. wymusić konieczność wysyłania maksymalnie jednego zapytania na daną jednostkę czasu. 

* Skorzystanie z jakiejś bramki API do przekierowywania ruchu, która współpracuje z Baselinkerem.
        
Z tego co się dowiedziałem istnieje również możliwość negocjacji maksymalnego limitu zapytan na minutę z obsługą Baselinkera.
        
Uważam, że nie ma tu jednego, najlepszego rozwiązania. Wszystko zależy od potrzeb, ilości zasóbów oraz tego jak duży jest ruch w sklepie.
W związku z tym, że nic nie było o tym wspomniane w poleceniu zadania, założyłem że ruch jest na tyle mały, iż moje obecne rozwiązanie problemu wystarczy na ten moment.
