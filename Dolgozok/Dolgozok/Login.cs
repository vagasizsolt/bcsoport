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
        public Login()
        {
            InitializeComponent();

            {

            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (felhasznalonev_textBox.Text == "" || jelszo_textBox.Text == "")
            {
                MessageBox.Show("Kérem adja meg a Felhasználónevét és a jelszavát!");
                return;
            }
            try

            {

                if ()

                {

                }

                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}