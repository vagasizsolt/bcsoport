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
    public partial class uzenet : Form
    {
        public uzenet()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(620, 400);
        }

        

        protected override void OnActivated(EventArgs e)
        {
            textBox2.Text = (Form1.cimzett);
            label3.Text = ("Jelenleg " + (Form1.cimzettnev) + " számára küldd üzenetet");
        }


        protected override void OnClosed(EventArgs e)
        {
            this.Hide();
            Form1 user = new Form1();
            user.Show();
        }

       
        private void visszabutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 user = new Form1();
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
                return;
            }
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("tamogatas.dolgozoadatbazis@gmail.com");
                message.To.Add(new MailAddress(Form1.cimzett));
                message.Subject = textBox1.Text;
                message.Body = richTextBox1.Text + Environment.NewLine +  "Ezt az üzenetet" + (Login.loginnev) + " küldte Önnek";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tamogatas.dolgozoadatbazis@gmail.com", "adminisztrator0");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("A levelet sikeresen elküldtük!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message);
            }
        }
    }
}
