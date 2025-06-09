# Zmeny oproti pôvodnému kódu (Program.cs)

Tento projekt bol kompletne refaktorovaný podľa princípov Clean Code a zadania. Tu je detailný prehľad zmien:

## 1. Rozdelenie do modulov a tried
- **Pôvodný stav:** Celá logika hry bola v jednej triede a metóde (`Program.Main`).
- **Nový stav:** Kód je rozdelený do samostatných tried podľa zodpovednosti:
  - `Game/Game.cs` – hlavná trieda, ktorá riadi zostavenie a spustenie hry.
  - `Game/Models/Snake.cs`, `Food.cs` – dátové modely hada a jedla.
  - `Game/Board/GameBoard.cs` – herná plocha a jej vykresľovanie.
  - `Game/Loop/GameLoop.cs` – hlavný herný cyklus.
  - `Game/Rendering/GameRenderer.cs` – vykresľovanie hada, jedla a skóre.
  - `Input/InputHandler.cs` – spracovanie vstupu od používateľa.
  - `Game/Config/GameConfig.cs` (+ JSON) – načítanie a validácia konfigurácie.
  - `Game/Logging/FileLogger.cs` – logovanie do súboru.
  - `Core/Position.cs`, `Core/Direction.cs` – pomocné dátové typy.

## 2. Decoupling logiky a GUI
- Herná logika (pohyb hada, kolízie, skóre) je oddelená od vykresľovania (`GameRenderer`), vstupu (`InputHandler`) a konfigurácie.
- Každá trieda má jasne definovanú zodpovednosť a rozhranie.

## 3. Konfigurácia a flexibilita
- Herné parametre (veľkosť, rýchlosť, znaky, farby) sú načítavané z `Config/config.json`.
- Možnosť meniť správanie hry bez zásahu do zdrojového kódu.

## 4. Logovanie
- Implementované robustné logovanie do súboru s rotáciou logov a úrovňami (Debug, Info, Warning, Error).
- Logovanie je použité vo všetkých dôležitých častiach hry.

## 5. Testovateľnosť a rozhrania
- Všetky hlavné komponenty majú rozhrania (`ISnake`, `IFood`, `IGameBoard`, `IGameRenderer`, `IInputHandler`, `ILogger`), čo umožňuje jednoduché testovanie a rozšíriteľnosť.

## 6. Ošetrenie chýb a robustnosť
- Všetky dôležité operácie sú ošetrené výnimkami a logovaním chýb.
- Validácia vstupov a konfigurácie.

## 7. Ostatné zásady Clean Code
- Zmysluplné pomenovanie premenných, metód a tried.
- Krátke, jednoúčelové metódy.
- Žiadne magické čísla – všetko je konfigurovateľné.
- Kód je čitateľný, rozšíriteľný a udržiavateľný.

## 8. .gitignore a štruktúra projektu
- Pridaný .gitignore pre C#/.NET projekty.
- Projekt je pripravený na verzovanie a tímovú spoluprácu.

---

**Záver:**
Projekt je teraz ukážkou moderného, čitateľného a rozšíriteľného C# kódu podľa zásad Clean Code a zadania. Všetka logika je oddelená od GUI, kód je modulárny, testovateľný a pripravený na ďalší rozvoj. 