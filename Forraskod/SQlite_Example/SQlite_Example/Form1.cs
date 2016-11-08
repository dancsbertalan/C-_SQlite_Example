using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//itt is be kell usingolni , mert az SQLiteDataReader ebbe a névtérbe van
using System.Data.SQLite;

namespace SQlite_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //ezzzel példányosítod az adatbázist
            Adatbazis db = Adatbazis.GetPeldany();

            //utána tudod használni
            //nézzünk egy inner join-os (foreign key) lekérdezést
            //ezt ki lehet próbálgatni a DB Browser for Sqlite programban (vagy a firefox-os kiegészítőben)
            //utána meg már csak be kell ide másolni az sql lekérdezés
            SQLiteDataReader reader = db.Lekerdezes("select fh.nev as 'Felhasználó' ,va.nev as 'Lakhely' from Felhasznalo fh inner join Varos va on fh.Lakhely = va.Iranyitoszam;");

            //majd feldolgozzuk (ezt felhasználó válogatja ,hogy mit akar feldolgozni - az az , hogy hova iratja ki vagy hova nem ..)
            //most csak logoltatom

            while (reader.Read())
            {
                //a reader beolvas egy sort majd azt kell indexelni ,hogy annak hanyadik oszlopában lévő adatra vagyunk kiváncsiak
                //field count megadja ,hogy hány oszlopunk van -> ez esetben most a lekérdezésnek 2 (az az indexelendő 0,1)
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    //a readernek van getint , getstring .... stb de ezeknek mindenképpen ilyet kell tudni be olvasni az adatbázisból
                    //viszont ha nem vagyunk biztosak abban amit beolvasunk akkor ott a get value - stringesítjük és utána lehet kezelni ahogy akarjuk
                    // i = 0 -> első oszlop az a név ez esetben
                    // i = 1 -> ez pedig a lakhelye ez esetben
                    //a getname adja vissza az oszlop nevét
                    MessageBox.Show(string.Format("{0}: {1}",reader.GetName(i),reader.GetValue(i).ToString()));
                }
                //de természetesen megoldható ,hogy az egész sort írja ki
                //ez egy adott sornak MINDEN értékét írja ki egyből
                //ilyenkor egy stringhez fűzödhozzá vagy lista vagy valami hasonló és azt iratod ki

            }

        }
    }
}
