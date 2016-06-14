#TrebboeBank
<b> Projekt zaliczeniowy na Akademie C# - Paweł Lelental </b>

1. Projektem jest aplikacja w WPF symulująca program który jest używany przez pracownika banku. Użytkownik może stworzyć nowe konto osobiste bądź firmowe dla potencjalnego klienta. Pracownik ma dostęp do listy kont w bazie (ObservableCollection zapisane w XML). Może on wpłacić środki na konto klienta, wypłacić oraz ma możliwość usunięcia klienta z bazy.

2. Przy rejestracji osoby fizycznej, program sprawdza:

   - poprawność imienia i nazwiska (przy wprowadzeniu cyfr zgłaszany jest bład)
   - poprawność numeru PESEL (zaimplementowany validator)
   - poprawność nr telefonu (każdy numer musi się zaczynać od '+' oraz musi być 9 cyfrowy)
   - datę urodzenia (rejestracja osób powyżej 18 roku życia)
  - email
   - wypełnienie pól (każde pole w formularzu musi zostać wypełnione)

  Dla rejestracji konta firmowego/biznesowego, sprawdzana jest:

   - poprawność nazwy firmy (identyczne założenie jak przy imieniu i nazwisku)
   - popranowść numeru Nip (zaimplementowany validator)
  - email, nr telefonu oraz wypełnienie pól ma założenia identyczne jak w przypadku rejestracji kont osobistych

  Dodatkowo dla każdego konta jest generowany poprawny numer rachunku bankowego, oraz id konta.

3. <b>Interfejs</b> - jest nim klasa "ICanSendCash" w Models->Operations. Klasami implementującymi interfejs są "Income" oraz "Withdraw". Odpowiednio w klasie "Income" sprawdzane jest czy zadawana kwota nie jest ujemna, zaś w klasie "Withdraw" czy kwota którą chcemy wypłacić nie przekracza środków na koncie klienta. Jeśli warunki są spełnienie, wybrana operacja zostanie dokonana. 

4. <b>Enum</b> - klasa "Gender" w Models->Accounts. Definiuje on płeć klienta. Zostosowany w klasie "PersonalAccounts"

5. <b>Dziedziczenie</b> - Klasy "PersonalAccounts" oraz "CompanyAccounts" dziedziczą pola klasy "Customers", w Models->Accounts.

6. <b>Kolekcje</b> - zostosowana została metoda ObservableCollection. Dodatkowo lista zapisywana jest do pliku XML. 

7. <b>Wyjątki</b> - zostały użyte m.in przy serializacji i deserializcji plików XML z listą klientów, w Models->Data. 




