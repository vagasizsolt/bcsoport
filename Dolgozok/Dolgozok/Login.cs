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
    public partial class Login : Form
    {
        public static string loginnev = "";

        Adatbazis db = Adatbazis.GetPeldany();


        public Login()
        {
            InitializeComponent();


            {
                Konstansok.LoginElem = this;
                
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new System.Drawing.Size(300, 300);

            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {

            if (felhasznalonev_textBox.Text == "" || jelszo_textBox.Text == "")
            {
                MessageBox.Show("Kérem adja meg a Felhasználónevét és a jelszavát!");
                return;
            }
            else
            {
                //try
                //{
                SQLiteDataReader felhasznalo = db.Lekerdezes("select * from Dolgozok where Felh_nev='" + felhasznalonev_textBox.Text + "'");
                if (felhasznalo.HasRows)
                {
                    string felh_nev = "";
                    string pw = "";
                    if (felhasznalo.Read())
                    {
                        felh_nev = felhasznalo.GetValue(7).ToString();
                        pw = felhasznalo.GetValue(8).ToString();
                    }

                    if ((felhasznalonev_textBox.Text == felh_nev.ToString() && jelszo_textBox.Text == pw.ToString()) == false)
                    {
                        MessageBox.Show("Hibás felhasználó név vagy jelszó!");
                    }
                    else
                    {
                        loginnev = felh_nev;
                        this.Hide();
                        Form1 user = new Form1();
                        user.Show();
                    }


                    //while (felhasznalo.Read())
                    //{
                    //    string nev = String.Format(String.Format("{0}", felhasznalo.GetValue(7)));
                    //    string pw = String.Format(String.Format("{0}", felhasznalo.GetValue(8)));
                    //    if (felhasznalonev_textBox.Text == nev.ToString() && jelszo_textBox.Text == pw.ToString())
                    //    {
                    //        loginnev = nev;
                    //        this.Hide();
                    //        Form1 user = new Form1();
                    //        user.Show();                             
                    //    }
                    //
                    //}
                }
                else
                {
                    MessageBox.Show("Nincs ilyen felhasználó");
                }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            jelszo_emlekezteto j = new jelszo_emlekezteto();
            j.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Resize(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(300, 300);

        }

        private void jelszo_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (felhasznalonev_textBox.Text == "" || jelszo_textBox.Text == "")
                {
                    MessageBox.Show("Kérem adja meg a Felhasználónevét és a jelszavát!");
                    return;
                }
                else
                {
                    //try
                    //{
                    SQLiteDataReader felhasznalo = db.Lekerdezes("select * from Dolgozok where Felh_nev='" + felhasznalonev_textBox.Text + "'");
                    if (felhasznalo.HasRows)
                    {
                        string felh_nev = "";
                        string pw = "";
                        if (felhasznalo.Read())
                        {
                            felh_nev = felhasznalo.GetValue(7).ToString();
                            pw = felhasznalo.GetValue(8).ToString();
                        }

                        if ((felhasznalonev_textBox.Text == felh_nev.ToString() && jelszo_textBox.Text == pw.ToString()) == false)
                        {
                            MessageBox.Show("Hibás felhasználó név vagy jelszó!");
                        }
                        else
                        {
                            loginnev = felh_nev;
                            this.Hide();
                            Form1 user = new Form1();
                            user.Show();
                        }


                        //while (felhasznalo.Read())
                        //{
                        //    string nev = String.Format(String.Format("{0}", felhasznalo.GetValue(7)));
                        //    string pw = String.Format(String.Format("{0}", felhasznalo.GetValue(8)));
                        //    if (felhasznalonev_textBox.Text == nev.ToString() && jelszo_textBox.Text == pw.ToString())
                        //    {
                        //        loginnev = nev;
                        //        this.Hide();
                        //        Form1 user = new Form1();
                        //        user.Show();                             
                        //    }
                        //
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Nincs ilyen felhasználó");
                    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                }
            }
        }



    }
}