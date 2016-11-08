<<<<<<< HEAD
Adatbázis modellhez használható -> http://dev.mysql.com/downloads/workbench/
DB Browser for Sqlite letölthető innen -> http://sqlitebrowser.org/
	(Ebben a foreign key-ek a tábla készítésekor megadhatóak, az alsó görgő sávon arébb kell mászni - és a foreignkeyhez beírni a kellő utasítást)

Amikor a projektet megcsináltad akkor jobb klikk az adott projektre és "manage nuget packages". 
Majd online megkeresed (browse menüpont) az "sqlite" parancsal a kiegészítőt. És a legfelsőt felrakod (aminek a 1.0.3 jelenleg a verziója). 
Majd a review changes-nél okét nyomunk.
=======
Amikor a projektet megcsináltad akkor jobb klikk az adott projektre és "manage nuget packages". 
Majd online megkeresed (browse menüpont) az "sqlite" parancsal a kiegészítőt. És a legfelsőt felrakod (aminek a 1.0.3 jelenleg a verziója). Majd a review changes-nél okét nyomunk.
>>>>>>> origin/master
Ha az végzett akkor a neki szükséges .DLL-eket berántja a projektnél a "references"-hez. Ott lehet ellenőrizni. A hozzá adott 3db references:
  - System.Data.SQlite
  - System.Data.SQlite.EF6
  - System.Data.SQite.Linq

Innentől kezdve minden követhető a .sln-ben.
<<<<<<< HEAD

=======
>>>>>>> origin/master
