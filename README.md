# Katalog

## Opis projektu

Aplikacja służy do tworzenia katalogu własnych pozycji, np. filmów, książek lub gier.

Aplikacja została wykonana w technologii C# i Avalonia.

Projekt zawiera trzy ekrany:
- listę pozycji,
- szczegóły wybranej pozycji,
- formularz dodawania nowej pozycji.

Dane są przechowywane w pliku `dane/pozycje.txt`.

## Plik z zasadami projektu

W projekcie wykorzystano plik `AGENTS.md`, który znajduje się w głównym katalogu projektu.

GitHub Copilot w Visual Studio Code obsługuje plik `AGENTS.md`. Może on zawierać zasady dotyczące struktury projektu, sposobu pisania kodu i wykonywania zadań.

Copilot obsługuje również własny format `.github/copilot-instructions.md`.

Plik `AGENTS.md` jest także obsługiwany przez OpenAI Codex. Pokazuje to, że warto znać ogólną kategorię plików z instrukcjami dla agentów AI, a nie tylko rozwiązanie jednego producenta.

Dokumentacja: https://code.visualstudio.com/docs/agents/reference/custom-instructions-reference

Data sprawdzenia dokumentacji: 17.11.2026.

## Sprawdzenie przestrzegania zasad

- Liczba zauważonych naruszeń zasad podczas pierwszego sprawdzenia: 0.
- Liczba zauważonych naruszeń zasad podczas ostatniego sprawdzenia: 0.

Podczas pracy nad projektem aplikacja działała poprawnie i nie zauważyłam problemów związanych z nieprzestrzeganiem zasad projektu przez agenta.

## Własnoręcznie wykonane zadanie

Samodzielnie dodałam przycisk „Policz”, który wyświetla liczbę pozycji zapisanych w pliku.

- Czas wykonania: około 5 minut.
- Najtrudniejsze było podłączenie zdarzenia `Click` do odpowiedniej metody w kodzie C#.