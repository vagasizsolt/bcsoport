using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Dolgozok
{
    public partial class tamogatas : Form
    {
        public tamogatas()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(545, 300);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
                return;
            }
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("felhasznalo.dolgozoadatbazis@gmail.com");
                message.To.Add(new MailAddress("tamogatas.dolgozoadatbazis@gmail.com"));
                message.Subject = textBox2.Text;
                message.Body = richTextBox1.Text;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("felhasznalo.dolgozoadatbazis@gmail.com", "felhasznalo0");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Köszönjük a visszajelzést!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 user = new Form1();
            user.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            Form1 user = new Form1();
            user.Show();
        }

        private void tamogatas_Resize(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(545, 300);
        }

    }
}
