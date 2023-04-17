# move-orders
W tym pliku opisuję wszystkie czynniki, jakie uwzględniłem przy tworzeniu mojego rozwiązania. 

## Ważne
* Miałem pewien problem z dokumentacją Baselinkera. Na przykład w dokumentacji metody addOrder parametr wejściowy order_status_id jest opisany jako typ liczbowy.
Jednakże na tej samej stronie dokumentacji w przykładowym inpucie, ten sam parametr jest przedstawiony w formacie json jako typu tekstowego:
```"order_status_id": "6624"```
Założyłem w tej i podobnych sytuacjach, że dokumentacja jest ważniejsza niż jej przykład użycia i przyjąłem typ (w tym konkretnym wypadku) liczbowy. 

* Dzięki możliwościom biblioteki Newtonsoft Json nie musiałem tworzyć właściwośći, z których nie będę korzystał. Dzięki atrybutowi ```[JsonProperty()]``` mogłem pobrać z Faire tylko te dane, które były mi potrzebne. Biblioteka ta korzysta również z domyślnego konstruktora do inicializacji obiektu. 

* W przypadku 6 punktu polecenia wydaje mi się, że jedynymi niezbędnymi właściwościami są te z 3, 4 i 7 punktu z zadania ze szczególnym naciskiem na ten ostatni, ponieważ do dodatkowego pola w baselinkerze dodaję id zamówienia z Faire. Najprawdopodobniej oznacza to, że nie trzeba przenosić innych pól, ponieważ w każdym zamówieniu w BL będziemy mieć podane id zamówienia z Faire. W związku z tym, że nie jestem całkowicie pewny ze względu na lakoniczność dokumentacji oraz brak możliwości przetestowania rozwiązania samemu, zmapowałem też inne pola, które wydają się odpowiadać za to samo w obu API (adres, szczegóły produktu itp.). Dodatkowo rozwija to też funkcjonalność mojego rozwiązania.

## Ograniczenia

### Pojedyncze przekazywanie zamówień
W dokumentacji BaseLinkera, do której mam dostęp nie ma metody, która pozwoliłaby na jednorazowe dodanie wszystkich zamówien, więc w metodzie ```AddBaseLinkerOrders``` z pomocą pętli iteruje po wszystkich zamówieniach i dodaje je po kolei po jednym.

### Przepustowość 
Dokumentacja Baselinkera informuje o przepustowości ograniczonej do 100 zapytań na minutę. Może nastąpić sytuacja, że jednorazowo będziemy chcieli dodać więcej niż 100 zamówień.
Jest to dosyć istotna kwestia, ponieważ przy przekroczeniu limitu, możliwośc wykonywania zapytań zostaje zablokowana na 10 min. Częściowo rozwiązałem ten problem za pomocą możliwości, jakie implementuje klasa TimerInfo, ponieważ po pierwszym wykonaniu funkcji będą pobierane jedynie zamówienia sprzed ostatnich 10 min, więc jest mała szansa na przekroczenie limitu.
Wszystko zależy od tego, jak duży jest ruch w sklepie, z którego pobieramy zamówienia.   
W celu całkowitej pewności, że problem ten nie wystąpi, widziałbym kilka możliwych rozwiązań:

* Stworzenie w funkcji służącej do wysyłania zapytań licznika w pętli, który po osiągnięciu danej liczby
(bezpieczniejszą wartością od 100 byłaby jakaś liczba około 95, bo w ciągu danej minuty mogły być też wykonane już przez nas jakieś inne operacje) zatrzyma wykonywanie programu na minutę.
To rozwiązanie jest najbardziej prymitywne i nie jestem jego zwolennikiem.

* Wymuszanie opóźnienia bezpośrednio pomiędzy przesyłaniem zapytań np. wymusić konieczność wysyłania maksymalnie jednego zapytania na daną jednostkę czasu. 

* Skorzystanie z jakiejś bramki API do przekierowywania ruchu, która współpracuje z Baselinkerem.
        
Z tego, co się dowiedziałem, istnieje również możliwość negocjacji maksymalnego limitu zapytań na minutę z pomocą techniczną Baselinkera.
        
Uważam, że nie ma tu jednego, najlepszego rozwiązania. Wszystko zależy od potrzeb, ilości zasobów oraz tego, jak duży jest ruch w sklepie.
W związku z tym, że nie było to wspomniane w poleceniu zadania, założyłem, że ruch jest na tyle mały, iż moje obecne rozwiązanie problemu wystarczy na ten moment.
