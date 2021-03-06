﻿using System;
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

using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Dolgozok
{
    public partial class Form1 : Form
    {
        private bool nevjegyNyomtatasMod = false;

        Adatbazis db = Adatbazis.GetPeldany();
        int i = 1;

        public static string cimzett = "";
        public static string cimzettnev = "";

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
            richTextBox1.ReadOnly = true;

            while (reader.Read())
            {
                SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                while (reszleg.Read() && beosztas.Read())
                {
                    ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                    nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                    reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                    beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                    email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                    telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));

                    string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                    System.Drawing.Image kepX = new Bitmap(eleres);
                    pictureBox1.Image = kepX;

                    cimzett = email_textbox.Text;
                    cimzettnev = nev_textbox.Text;
                }
            }



            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(815, 525);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = i + 1;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + j);
            if (reader.HasRows == true)
            {
                i++;
                while (reader.Read())
                {
                    SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                    SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                    while (reszleg.Read() && beosztas.Read())
                    {
                        ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                        nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                        reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                        beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                        email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                        telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                        string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                        System.Drawing.Image kepX = new Bitmap(eleres);
                        pictureBox1.Image = kepX;

                        cimzett = email_textbox.Text;
                        cimzettnev = nev_textbox.Text;

                        richTextBox1.Text = "";
                    }
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
                    SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                    SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                    while (reszleg.Read() && beosztas.Read())
                    {
                        ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                        nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                        reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                        beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                        email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                        telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                        string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                        System.Drawing.Image kepX = new Bitmap(eleres);
                        pictureBox1.Image = kepX;

                        cimzett = email_textbox.Text;
                        cimzettnev = nev_textbox.Text;

                        richTextBox1.Text = "";
                    }
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
                pictureBox2.Visible = false;
                textBox1.Visible = false;
                comboBox1.Visible = false;
                checkBox1.Visible = false;
                aktivlogin.Visible = false;
                keresbutton.Visible = false;
                listBox1.Visible = false;
                richTextBox1.Visible = false;
                bejegyzesbox.Visible = false;
                bejegyzes.Visible = false;
                frissbutton.Visible = false;

                this.FormBorderStyle = FormBorderStyle.None;

                System.Drawing.Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(@"Adatbazis\nevjegy.jpg", ImageFormat.Jpeg);
                }

                Document document = new Document();
                using (var stream = new FileStream(@"Adatbazis\nevjegy.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    using (var imageStream = new FileStream(@"Adatbazis\nevjegy.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = iTextSharp.text.Image.GetInstance(imageStream);
                        document.Add(image);
                    }
                    document.Close();
                }

                System.Diagnostics.Process.Start(@"Adatbazis\nevjegy.pdf");
                
            }
            System.Windows.Forms.MessageBox.Show("A nyomtatás nézetből az Esc-el léphet ki!");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                nevjegyNyomtatasMod = false;
                menuStrip1.Visible = true;
                elozo_button.Visible = true;
                kovetkezo_button.Visible = true;
                pictureBox2.Visible = true;
                textBox1.Visible = true;
                comboBox1.Visible = true;
                checkBox1.Visible = true;
                aktivlogin.Visible = true;
                keresbutton.Visible = true;
                listBox1.Visible = true;
                richTextBox1.Visible = true;
                bejegyzesbox.Visible = true;
                bejegyzes.Visible = true;
                frissbutton.Visible = true;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
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
                    pictureBox2.Visible = true;
                    textBox1.Visible = true;
                    comboBox1.Visible = true;
                    checkBox1.Visible = true;
                    aktivlogin.Visible = true;
                    keresbutton.Visible = true;
                    listBox1.Visible = false;
                    richTextBox1.Visible = true;
                    bejegyzesbox.Visible = true;
                    bejegyzes.Visible = true;
                    frissbutton.Visible = true;
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    return true;
                }
            }
            return base.ProcessDialogKey(keydata);
        }

        protected override void OnClosed(EventArgs e)
        {
            Program.l.Close();
            base.OnClosed(e);
        }

        private void támogatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            tamogatas tamogatas = new tamogatas();
            tamogatas.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            aktivlogin.Text = ( Login.loginnev);
        }

        private void kijelentkezésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }

            richTextBox1.Visible = false;
            bejegyzesbox.Visible = false;
            bejegyzes.Visible = false;
            frissbutton.Visible = false;
            listBox1.Visible = false;
        }

        private void keresbutton_Click(object sender, EventArgs e)
        {
            string mit = textBox1.Text;
            string mialapjan = comboBox1.Text;

            List<string> elemek = new List<string>();

            listBox1.Items.Clear();

            if (textBox1.Text=="" ||comboBox1.Text=="")
            {
                MessageBox.Show("Kérem írja be, hogy mit vagy mi alapján szeretne keresni");

            }
            else
            {
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    if (mialapjan == "Reszleg")
                    {
                        SQLiteDataReader seged = db.Lekerdezes("select * from Reszlegek where Reszleg ='" + mit + "'");
                        if (seged.HasRows == true)
                        {
                            while (seged.Read())
                            {
                                SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where " + mialapjan + " ='" + seged.GetValue(0) + "'");
                                if (reader.HasRows == true)
                                {
                                    while (reader.Read())
                                    {
                                        SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                        SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                        while (reszleg.Read() && beosztas.Read())
                                        {
                                            ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                                            nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                                            reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                                            beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                                            email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                                            telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                                            string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                                            System.Drawing.Image kepX = new Bitmap(eleres);
                                            pictureBox1.Image = kepX;

                                            listBox1.Visible = true;

                                            elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                            + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                        }
      
                                    }
                                    for (int i = 0; i < elemek.Count(); i++)
                                    {
                                        listBox1.Items.Add(elemek[i]);
                                        listanezetklikk = true;
                                    }
                                }
                            }
                        }
                        if (elemek.Count() == 0)
                        {
                            MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                        }
                    }
                    else
                    {
                        if (mialapjan == "Beosztas")
                        {
                            SQLiteDataReader seged = db.Lekerdezes("select * from Beosztasok where Beosztas ='" + mit + "'");
                            if (seged.HasRows == true)
                            {
                                while (seged.Read())
                                {
                                    SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where " + mialapjan + " ='" + seged.GetValue(0) + "'");
                                    if (reader.HasRows == true)
                                    {
                                        while (reader.Read())
                                        {
                                            SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                            SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                            while (reszleg.Read() && beosztas.Read())
                                            {
                                                ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                                                nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                                                reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                                                beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                                                email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                                                telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                                                string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                                                System.Drawing.Image kepX = new Bitmap(eleres);
                                                pictureBox1.Image = kepX;

                                                listBox1.Visible = true;

                                                elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                            + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                            }
                                        }
                                        for (int i = 0; i < elemek.Count(); i++)
                                        {
                                            listBox1.Items.Add(elemek[i]);
                                            listanezetklikk = true;
                                        }
                                    }
                                }
                            }
                            if (elemek.Count() == 0)
                            {
                                MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                            }
                        }
                        else
                        {
                            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where " + mialapjan + " ='" + mit + "'");
                            if (reader.HasRows == true)
                            {
                                while (reader.Read())
                                {
                                    SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                    SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                    while (reszleg.Read() && beosztas.Read())
                                    {
                                        ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                                        nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                                        reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                                        beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                                        email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                                        telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                                        string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                                        System.Drawing.Image kepX = new Bitmap(eleres);
                                        pictureBox1.Image = kepX;

                                        listBox1.Visible = true;

                                        elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                    + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                    }
                                }
                                for (int i = 0; i < elemek.Count(); i++)
                                {
                                    listBox1.Items.Add(elemek[i]);
                                    listanezetklikk = true;
                                }
                            }
                            if (elemek.Count() == 0)
                            {
                                MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                            }
                        }
                    }
                }
                else
                {
                    if (checkBox1.CheckState == CheckState.Unchecked)
                    {
                        if (mialapjan == "Beosztas")
                        {
                            SQLiteDataReader seged = db.Lekerdezes("select * from Beosztasok where Beosztas LIKE'%" + mit + "%'");
                            if (seged.HasRows == true)
                            {
                                while (seged.Read())
                                {
                                    SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where Beosztas=" + seged.GetValue(0));
                                    if (reader.HasRows == true)
                                    {
                                        while (reader.Read())
                                        {
                                            SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                            SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                            while (beosztas.Read() && reszleg.Read())
                                            {
                                                listBox1.Visible = true;

                                                elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                        + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                            }
                                            for (int i = 0; i < elemek.Count(); i++)
                                            {
                                                listBox1.Items.Add(elemek[i]);
                                                listanezetklikk = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (elemek.Count() == 0)
                            {
                                MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                            }
                        }
                        else
                        {
                            if (mialapjan == "Reszleg")
                            {
                                SQLiteDataReader seged = db.Lekerdezes("select * from Reszlegek where Reszleg LIKE'%" + mit + "%'");
                                if (seged.HasRows == true)
                                {
                                    while (seged.Read())
                                    {
                                        SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where Reszleg=" + seged.GetValue(0));
                                        if (reader.HasRows == true)
                                        {
                                            while (reader.Read())
                                            {
                                                SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                                SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                                while (beosztas.Read() && reszleg.Read())
                                                {
                                                    listBox1.Visible = true;

                                                    elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                            + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                                }
                                                for (int i = 0; i < elemek.Count(); i++)
                                                {
                                                    listBox1.Items.Add(elemek[i]);
                                                    listanezetklikk = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (elemek.Count() == 0)
                                {
                                    MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                                }
                            }
                            else
                            {
                                SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where " + mialapjan + " LIKE'%" + mit + "%'");
                                if (reader.HasRows == true)
                                {
                                    while (reader.Read())
                                    {
                                        SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                                        SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                                        while (beosztas.Read() && reszleg.Read())
                                        {
                                            listBox1.Visible = true;

                                            elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                                                            + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                                        }
                                    }
                                    for (int i = 0; i < elemek.Count(); i++)
                                    {
                                        listBox1.Items.Add(elemek[i]);
                                        listanezetklikk = true;
                                    }
                                }
                                if (elemek.Count() == 0)
                                {
                                    MessageBox.Show("Nincs a keresésnek megfelelő elem az adatbázisban!");
                                }
                            }
                        }
                    }
                }                               
            }                      
        }

        private void faliújságMegjelenítéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            bejegyzesbox.Visible = true;
            bejegyzes.Visible = true;
            frissbutton.Visible = true;
            SQLiteDataReader reader = db.Lekerdezes("select * from Faliujsag WHERE'" + ID_textbox.Text + "'=D_ID");

            List<string> result_friss = new List<string>();

            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    result_friss.Add(reader.GetValue(1).ToString() + System.Environment.NewLine + reader.GetValue(2).ToString() + System.Environment.NewLine);
                }
            }

            richTextBox1.Text = String.Join(System.Environment.NewLine, result_friss);



        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(815, 525);
        }

        private void bejegyzes_Click(object sender, EventArgs e)
        {
            SQLiteDataReader writer = db.Lekerdezes("insert into Faliujsag (Szoveg,Modositotta,D_ID) values ('" 
                + bejegyzesbox.Text + "','" + aktivlogin.Text + "','" + ID_textbox.Text + "')");

            System.Windows.Forms.MessageBox.Show("Bejegyzés sikeres!");            
            
        }

        private void frissbutton_Click(object sender, EventArgs e)
        {
            SQLiteDataReader reader = db.Lekerdezes("select * from Faliujsag WHERE'" + ID_textbox.Text +"'=D_ID");

            List<string> result_friss = new List<string>();

            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    result_friss.Add(reader.GetValue(1).ToString() + System.Environment.NewLine + reader.GetValue(2).ToString() + System.Environment.NewLine);
                }
            }

            richTextBox1.Text = String.Join(System.Environment.NewLine, result_friss);



        }

        private bool listanezetklikk = false;

        private void listaNézetMegjelenítéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;

            
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok");

            List<string> elemek = new List<string>();

            if(listanezetklikk == false)
            {
                if (reader.HasRows == true)
                {
                    i++;
                    while (reader.Read())
                    {
                        SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                        SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                        while (beosztas.Read() && reszleg.Read())
                        {
                            elemek.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reszleg.GetValue(0).ToString()
                            + " " + beosztas.GetValue(0).ToString() + System.Environment.NewLine + " ");
                        }
                    }
                }

                for (int i = 0; i < elemek.Count(); i++)
                {
                    listBox1.Items.Add(elemek[i]);
                    listanezetklikk = true;
                }
            }          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex + 1;
            SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where ID=" + index);
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    SQLiteDataReader beosztas = db.Lekerdezes("select Beosztas from Beosztasok where ID=" + reader.GetValue(3));
                    SQLiteDataReader reszleg = db.Lekerdezes("select Reszleg from Reszlegek where ID=" + reader.GetValue(2));
                    while (reszleg.Read() && beosztas.Read())
                    {
                        ID_textbox.Text = (String.Format("{0}", reader.GetValue(0)));
                        nev_textbox.Text = (String.Format("{0}", reader.GetValue(1)));
                        reszleg_textbox.Text = (String.Format("{0}", reszleg.GetValue(0)));
                        beosztas_textbox.Text = (String.Format("{0}", beosztas.GetValue(0)));
                        email_textbox.Text = (String.Format("{0}", reader.GetValue(4)));
                        telefonszam_textbox.Text = (String.Format("{0}", reader.GetValue(5)));
                        string eleres = Environment.CurrentDirectory + @"\Adatbazis" + reader.GetValue(6).ToString();
                        System.Drawing.Image kepX = new Bitmap(eleres);
                        pictureBox1.Image = kepX;

                        richTextBox1.Text = "";
                    }
                }
            }
        }

        private void összesElrejtéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            richTextBox1.Visible = false;
            bejegyzesbox.Visible = false;
            bejegyzes.Visible = false;
            frissbutton.Visible = false;
        }

        private void üzenetÍrásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            uzenet uzenet = new uzenet();
            uzenet.Show();
        }


    }
}
