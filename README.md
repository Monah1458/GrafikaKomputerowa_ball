# GrafikaKomputerowa_ball

GDD – BALLANCE

Silnik gry: Unity
Platforma: PC (Windows)
Gatunek: gra zręcznościowa 3D
Tryb gry: single player
Perspektywa: trzecioosobowa

1. Opis gry

Ballance to gra zręcznościowa 3D, w której gracz steruje kulką poruszającą się po wąskich platformach zawieszonych nad przepaścią. Celem jest dotarcie do końca poziomu, unikając upadków i przeszkód.

Gra skupia się na precyzyjnym sterowaniu, fizyce ruchu oraz utrzymywaniu kulki na trasie.

2. Cel gry

Celem gracza jest ukończenie wszystkich poziomów. Aby to zrobić, musi kontrolować prędkość kulki, pokonywać zakręty i omijać przeszkody.

3. Główne mechaniki

- Toczenie kulki w wybranym kierunku.
- Przyspieszanie i zwalnianie.
- Pokonywanie przeszkód.
- Upadek z trasy i ponowne rozpoczęcie poziomu.
- Dotarcie do mety, aby ukończyć poziom.
- Przesuwanie obiektów przez kulkę.
- Zmiana materiału, a tym samym zmiana wagi kulki.

4. Sterowanie

Klawisz| Funkcja:
- W| Ruch do przodu
- S| Ruch do tyłu
- A| Ruch w lewo
- D| Ruch w prawo
- Esc| Pauza

Sterowanie zostanie zaimplementowane w Unity. Ruch kulki będzie oparty na fizyce 3D.

5. Projekt poziomów

Gra będzie składać się z kilku poziomów o rosnącym poziomie trudności.

- Poziom 1: prosta trasa, nauka sterowania, proste pokonywanie przeszkód

Każdy poziom będzie kończył się w wyznaczonym punkcie mety.

6. Grafika

Gra będzie wykonana w grafice 3D. Najważniejszym obiektem będzie kulka, która będzie wyróżniać się na tle otoczenia.
Poziomy będą składać się z platform, ramp i przeszkód. Otoczenie będzie minimalistyczne, aby gracz mógł łatwo rozpoznawać trasę.

7. Dźwięk

W grze zostaną wykorzystane:
- dźwięki toczenia kulki;
- dźwięki zderzeń z przeszkodami;
- muzyka w tle;
- sygnał ukończenia poziomu.

8. Kamera i interfejs

Kamera będzie podążać za kulką, pokazując trasę przed graczem.

Interfejs będzie prosty i będzie zawierał:
- menu główne;
- przycisk rozpoczęcia gry;
- menu pauzy;
- informację o ukończeniu poziomu.

9. Technologia

Gra zostanie stworzona w silniku Unity.

Do wykonania podstawowej wersji zostaną wykorzystane:
- modele 3D kulki i platform;
- system fizyki Unity;
- skrypty C# do sterowania kulką;
- kamera podążająca za graczem;
- kolizje wykrywające upadek i ukończenie poziomu.

10. Plan wykonania

- Przygotowanie sceny i platform w Unity.
- Stworzenie kulki i dodanie fizyki.
- Implementacja sterowania w C#.
- Dodanie kamery podążającej za kulką.
- Zaprojektowanie poziomów i przeszkód.
- Dodanie mety oraz obsługi upadku.
- Testowanie i poprawianie błędów.

11. Podsumowanie

Ballance to prosta gra zręcznościowa 3D, której główną mechaniką jest sterowanie kulką na wąskich platformach. Projekt ma na celu stworzenie grywalnej wersji w Unity, zawierającej podstawowe sterowanie, fizykę, przeszkody i kilka poziomów o rosnącym poziomie trudności.