# LSVRP Gamemode Rage (C#)

Skrypt uruchamiany w środowisku CoreCLR (.NET Core). Korzysta z bazy danych MySQL poprzez ORMa *Entity Framework Core*.
Dodatkowo uruchamiany jest serwer UDP, który nasłuchuje poleceń pochodzących z aplikacji webowej i stosujących zmiany dynamicznie.

Po stronie klienta używa silnika V8 do obsługi JavaScriptu. Interfejs stworzony jest przy pomocy HTMLa, który uruchamiany jest przy pomocy CEFa (Chromium Embedded Framework).