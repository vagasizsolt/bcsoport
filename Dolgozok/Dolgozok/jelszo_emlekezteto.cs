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

using System.Net;
using System.Net.Mail;

namespace Dolgozok
{
    public partial class jelszo_emlekezteto : Form
    {
        Adatbazis db = Adatbazis.GetPeldany();
        public jelszo_emlekezteto()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(350, 220);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Kérem adjon meg egy e-mail címet!");
                return;
            }
            else
            {
                try
                {
                    SQLiteDataReader email = db.Lekerdezes("select * from Dolgozok where Email='" + textBox1.Text + "'");
                    if (email.HasRows)
                    {
                        while (email.Read())
                        {
                            string mail = String.Format(String.Format("{0}", email.GetValue(4)));
                            if (textBox1.Text == mail.ToString())
                            {
                                try
                                {
                                    MailMessage message = new MailMessage();
                                    SmtpClient smtp = new SmtpClient();

                                    message.From = new MailAddress("tamogatas.dolgozoadatbazis@gmail.com");
                                    message.To.Add(new MailAddress(textBox1.Text));
                                    message.Subject = "Jelszó emlékezetető dolgozói adatbázishoz";
                                    message.Body = String.Format(String.Format("Az Ön jelszava: {0}", email.GetValue(8)));

                                    smtp.Port = 587;
                                    smtp.Host = "smtp.gmail.com";
                                    smtp.EnableSsl = true;
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = new NetworkCredential("tamogatas.dolgozoadatbazis@gmail.com", "adminisztrator0");
                                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtp.Send(message);
                                    MessageBox.Show("A jelszavát elküldtük a megadott e-mail címre");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Hiba " + ex.Message);
                                }
                                
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ilyen e-mail cím nem szerepel az adatbázisunkban.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void jelszo_emlekezteto_Resize(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(350, 220);
        }
    }
}
