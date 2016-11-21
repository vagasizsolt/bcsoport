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
            Adatbazis db = Adatbazis.GetPeldany();

            do
            {
                SQLiteDataReader reader = db.Lekerdezes("select * from Dolgozok where Felh_nev =" + felhasznalonev_textBox);
                string pw = (string.Format("{0}", reader.GetValue(9)));
                if (jelszo_textBox.Equals(pw))
                {
                    this.Hide();
                    Form1 user = new Form1();
                    user.Show();
                }
            } while (false);

        }
    }
}