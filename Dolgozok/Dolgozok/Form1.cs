using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace Dolgozok
{
    public partial class Form1 : Form
    {
        Adatbazis db = Adatbazis.GetPeldany();
        int i = 1;
        public Form1()
        {
            InitializeComponent();
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + i);
            ID_textbox.ReadOnly = true;
            nev_textbox.ReadOnly = true;
            reszleg_textbox.ReadOnly = true;
            beosztas_textbox.ReadOnly = true;
            email_textbox.ReadOnly = true;
            telefonszam_textbox.ReadOnly = true;

            while (reader.Read())
            {
                ///ezt valamilyen ciklussal meglehet oldani?
                ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));

                string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                Image kepX = new Bitmap(eleres);
                pictureBox1.Image = kepX;

                ///ide meg majd kéne, hogy lehessen léptetni az egyes dolgozókat
                ///illetev az is kéne, hogy ne lehessen törölni belőlük
                ///később login form segítségével a jogosultságok persze szabályozva lesznek, hogy ki törölhet, ki módosíthat, ki csak nézhet, stb...
                ///+még az adatbázis is kiegészítve lesz több táblával, képpel, meg egyebekkel
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + i);
            while (reader.Read())
            {
                ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + i);
            while (reader.Read())
            {
                ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
            }
        }



    }
}
