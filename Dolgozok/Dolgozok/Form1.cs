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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Dolgozok
{
    public partial class Form1 : Form
    {

        private bool nevjegyNyomtatasMod = false;



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
                ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));

                string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                Image kepX = new Bitmap(eleres);
                pictureBox1.Image = kepX;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = i + 1;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + j);
            if(reader.HasRows==true)
            {
                i++;
                while (reader.Read())
                {
                    ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                    nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                    reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                    beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                    email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                    telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                    string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                    Image kepX = new Bitmap(eleres);
                    pictureBox1.Image = kepX;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j = i - 1;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + j);
            if (reader.HasRows == true)
            {
                i--;
                while (reader.Read())
                {
                    ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                    nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                    reszleg_textbox.Text = (String.Format("{0}", reader.GetValue(2)));
                    beosztas_textbox.Text = (String.Format("{0}", reader.GetValue(3)));
                    email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                    telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                    string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                    Image kepX = new Bitmap(eleres);
                    pictureBox1.Image = kepX;
                }
            }
        }


        public void jegyzettömbbenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> adatok = new List<string>();

            adatok.Add(nev_textbox.Text);
            adatok.Add(reszleg_textbox.Text);
            adatok.Add(beosztas_textbox.Text);
            adatok.Add(email_textbox.Text);
            adatok.Add(telefonszam_textbox.Text);

            File.WriteAllText(@"Adatbazis\adatok.txt", String.Empty);

            for (int i = 0; i < adatok.Count; i++)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"Adatbazis\adatok.txt", true);
                file.WriteLine(adatok[i]);
                file.Close();
            }
            System.Diagnostics.Process.Start("notepad.exe", @"Adatbazis\adatok.txt");
        }

        private void vágólapraMásolásToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Clipboard.Clear();
            List<string> adatok_vagolap = new List<string>();

            adatok_vagolap.Add(nev_textbox.Text);
            adatok_vagolap.Add(reszleg_textbox.Text);
            adatok_vagolap.Add(beosztas_textbox.Text);
            adatok_vagolap.Add(email_textbox.Text);
            adatok_vagolap.Add(telefonszam_textbox.Text);

            Clipboard.SetText(adatok_vagolap[0] + Environment.NewLine + adatok_vagolap[1] + Environment.NewLine + adatok_vagolap[2]
                +Environment.NewLine + adatok_vagolap[3] + Environment.NewLine + adatok_vagolap[4]);

            System.Windows.Forms.MessageBox.Show("Adatok sikeresen vágólapra másolva");

        }

        private void névjegyNyomtatásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(nevjegyNyomtatasMod ==false)
            {
                nevjegyNyomtatasMod = true;
                menuStrip1.Visible = false;
                elozo_button.Visible = false;
                kovetkezo_button.Visible = false;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                nevjegyNyomtatasMod = false;
                menuStrip1.Visible = true;
                elozo_button.Visible = true;
                kovetkezo_button.Visible = true;
            }
        }

        protected override bool ProcessDialogKey(Keys keydata)
        {
            if (nevjegyNyomtatasMod == true)
            {
                if(Form.ModifierKeys == Keys.None && keydata == Keys.Escape)
                {
                    nevjegyNyomtatasMod = false;
                    menuStrip1.Visible = true;
                    elozo_button.Visible = true;
                    kovetkezo_button.Visible = true;
                    return true;
                }
            }
            return base.ProcessDialogKey(keydata);
        }






    }
}
