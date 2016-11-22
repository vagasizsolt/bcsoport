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
        Adatbazis db = Adatbazis.GetPeldany();
        public Login()
        {
            InitializeComponent();

            {
                Konstansok.LoginElem = this;
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
                try
                {
                    SQLiteDataReader felhasznalo = db.Lekerdezes("select * from Dolgozok where Felh_nev='" + felhasznalonev_textBox.Text + "'");
                    if (felhasznalo.HasRows)
                    {
                        while (felhasznalo.Read())
                        {
                            string nev = String.Format(String.Format("{0}", felhasznalo.GetValue(7)));
                            string pw = String.Format(String.Format("{0}", felhasznalo.GetValue(8)));
                            if (felhasznalonev_textBox.Text == nev.ToString() && jelszo_textBox.Text == pw.ToString())
                            {
                                this.Hide();
                                Form1 user = new Form1();
                                user.Show();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Hibás felhasználónév vagy jelszó!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}