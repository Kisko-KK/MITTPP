# Metode i tehnike testiranja programske podrške - Projektni zadatak

## 1. Opis projekta
U projektu je bilo potrebno stvoriti okvir (eng. *framework*) za automatsko testiranje programske podrške te odabrati programsku podršku i alate, proizvoljno. Odabrano je korištenje xUnit testova u .NET razvojnom okviru.
U projektu je napravljeno 6 testova kojima se automatski testira ispravnost testnog *web shop*-a [SauceDemo](https://www.saucedemo.com/).

## 2. Korištene tehnologije
### 2.1 Visual Studio 2022
Visual Studio 2022 je integrirano razvojno okruženje (IDE) razvijeno od strane Microsofta, koje pruža bogat skup alata za razvoj softvera. Ovo okruženje podržava širok spektar tehnologija, programskih jezika i platformi, omogućujući stvaranje raznovrsnih vrsta aplikacija, uključujući web, desktop, mobilne, cloud i IoT aplikacije.
### 2.2 Selenium
Selenium je popularan alat otvorenog koda za automatizaciju web preglednika. Razvijen je kako bi omogućio programerima i testerima automatsko testiranje web aplikacija na različitim preglednicima i platformama. Selenium se često koristi u agilnim razvojnim timovima kako bi osigurao kvalitetu web aplikacija kroz automatizaciju testova, smanjujući prilike za ljudske pogreške i ubrzavajući ciklus razvoja. Selenium podržava različite jezike poput Java, C#, Python, Ruby, i mnoge druge, čime omogućava programerima da pišu testove u jeziku koji im je najpoznatiji. Također podržava različite preglednike kao što su Chrome, Firefox, Edge, itd.
### 2.3 xUnit
xUnit je besplatan i otvoren okvir za testiranje softvera koji podržava razvoj i izvođenje testova jedinica (eng. *unit test*) u različitim programskim jezicima, uključujući C#, F#, Java, JavaScript, Python i mnoge druge. Ovaj okvir je osmišljen kako bi pružio jednostavnu i konzistentnu platformu za pisanje i izvršavanje testova jedinica, promovirajući pritom dobre prakse u testiranju softvera.
## 3. Upute za instalaciju i korištenje projekta
 - Potrebno je imati instaliran Visual Studio 2022
 - Nakon otvaranja projekta, potrebno je "buildati" projekt prilikom čega će se instalirati potrebni NuGet paketi
![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/8fcb230b-0951-4a91-a816-af63ae931ee3)

 - Pokretanje testova moguće je preko: Test -> Run All Tests
 ![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/3ac37bfe-92c0-4f3c-a284-8a887d983f89)
## 4. Testovi
U ovim primjerima, koristi se xUnit za pisanje testova u C# jeziku. Testovi su fokusirani na funkcionalnostima web stranice [Saucedemo](https://www.saucedemo.com/) koristeći Selenium WebDriver Chrome. Također, koristi se Page Object Model (POM) pristup, gdje se svaka korištena stranica modelira kao odvojeni objekt kako bi se omogućila bolja modularnost i čitljivost koda. **U sljedećim primjerima pokazan je samo testni dio koda, bez inicijalizacije te klasa koje predstavljaju POM.**
### 4.1 Struktura projekta
![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/fbdcc0a4-b4aa-4345-bc95-5be66a5bb16f)

### 4.2 Prvi i drugi testni slučaj
Ovaj set Selenium testova provjerava funkcionalnosti prijave na web stranici "[https://www.saucedemo.com/](https://www.saucedemo.com/)". Prvi test potvrđuje da se korisnik s valjanim podacima uspješno prijavljuje i preusmjerava na stranicu s proizvodima, dok drugi test provjerava da se korisnik s nevažećim podacima ne prijavljuje i ostaje na istoj stranici.

![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/1a44e6ca-2fac-41c8-9d60-d0c1832d3f2d)
### 4.3 Treći testni slučaj
Ovaj Selenium test provjerava funkcionalnost dodavanja proizvoda na već navedenoj web stranici. Test potvrđuje da klik na gumb za dodavanje proizvoda ("Sauce Labs Backpack") rezultira prikazivanjem gumba za uklanjanje proizvoda. Testovi su izvršeni nakon što je korisnik uspješno prijavljen s valjanim podacima.

![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/a368e412-be58-4829-b611-39b97474b7b8)
### 4.4 Četvrti testni slučaj
  
Ovi Selenium test provjeravaju funkcionalnost dodavanja proizvoda u košaricu. Konkretno, test potvrđuje da dodavanje proizvoda ("Sauce Labs Backpack") rezultira odlaskom na stranicu košarice, ispravno prikazivanje proizvoda u košarici. Testovi su također izvršeni nakon što je korisnik uspješno prijavljen s valjanim podacima.

![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/ac722884-23ee-4faf-81f0-62c08362c8e6)
### 4.5 Peti i šesti testni slučaj
Ovi Selenium testovi provjeravaju proces dodavanja dva proizvoda ("Sauce Labs Backpack" i "Sauce Labs Bike Light") u košaricu. Nakon dodavanja proizvoda u košaricu, testovi nastavljaju s procesom odlaska na blagajnu, unosa korisničkih podataka (ime, prezime, poštanski broj), te zatim dovršavaju proces plaćanja.

Prvi test, "AddTwoItemsToCart_VerifyCheckout", pokriva osnovni tok procesa blagajne, dok drugi test, "AddTwoItemsToCart_VerifyCheckoutPrice", dodatno provjerava točnost ukupne cijene nakon dovršenja procesa plaćanja. Oba testa se također izvršavaju nakon što se korisnik uspješno prijavi s valjanim podacima.

![image](https://github.com/Kisko-KK/MITTPP/assets/67562727/b6cb700a-0456-43de-9e27-9a16495b4b39)
