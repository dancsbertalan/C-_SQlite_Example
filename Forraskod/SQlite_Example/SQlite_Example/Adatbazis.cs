using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //ezt a névteret használom arra ,hogy meghatározzam az adatbázis fájl mappáját (amely itt található /projekt/debug/Adatbazis - ezt akarjuk dinamikusan
//meghatározni
//az adatbázis kapcsolathoz szükséges névtér(ek)
using System.Data.SQLite;

namespace SQlite_Example
{
    class Adatbazis
    {
        //felfesszük private-ként ,hogy csak belül tudjuk használni de ott minden metóduson belül
        SQLiteConnection conn;

        #region singleton
        /// <summary>
        /// Adatbázis példányosításakor megnyitjuk a kapcsolatot.
        /// </summary>
        private Adatbazis() {
            //string melyel elérjük az adatbázist (nem használunk direkt linket - hanem a program futási környezetből keressük meg az 
            // adatbázis fájlt - mert ha telepítjük máshova a programot akkor át kéne írni a direkt linket ...)
            string adatbEleres = Directory.GetCurrentDirectory() + @"\Adatbazis\Adatbazis.db"; //currentdirectory meghatározza a jelenlegi futtatási környezetet - az az azt az elérést
            //ahol maga a futtatható exe van! ehhez kell hozzáfűzni a mi elérésünk az adatbzishoz

            //ezen az elérése létre hozzuk a 
            //az eléréshez szükség van a látható stringre - version az a driver verziója az 3 .....
            conn = new SQLiteConnection(string.Format("Data Source = {0};Version = 3;", adatbEleres));
            //továbbá lehet itt olyanokat megoldani ,hogy elsőnek megnézi ,hogy létezik-e ez a .db db fájl és ha nem létezik akkor
            // create table ....... stb-kkel elkészít a táblát a felhasználónak (parktikus első indításkor) - vagy a projekt telepítőjébe
            // bele kell integrálni majd az adatbázist az adott elérésen -- prjekt\adatbazis\adatbazis.db
            conn.Open();

        }
        private static Adatbazis peldany = null;
        /// <summary>
        /// Amikor az adatbázist elkészítjük, akkor egyből meg is nyitjuk
        /// </summary>
        /// <returns></returns>
        public static Adatbazis GetPeldany() {
            if (peldany == null)
            {
                peldany = new Adatbazis();
            }
            return peldany;
        }

        /// <summary>
        /// Paraméterben meg adhatod a lekerdezest (példa ->"select * from tablanev") Fontos ,hogy itt csak selectek lehetnek
        /// Hiszen ez csak executeReader-t használ - és ez readerrel tér vissza - 
        /// </summary>
        /// <param name="lekerdezes"></param>
        /// <returns></returns>
        public SQLiteDataReader Lekerdezes(string lekerdezes) {
            SQLiteCommand comm = new SQLiteCommand(lekerdezes,conn); //itt a végrehajtandó lekérdezést kell átadni illetve ,hogy milyen adatbázison
            SQLiteDataReader reader = comm.ExecuteReader(); //végre hajta a beolvasást

            return reader; //vissza adod ezt a readert (ami ilyenkor nyitva is lesz!)
        }
        #endregion

    }
}
