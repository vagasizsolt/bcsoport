namespace Dolgozok
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.felhasznalonev_textBox = new System.Windows.Forms.TextBox();
            this.jelszo_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(103, 163);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Felhasznalonev";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jelszo";
            // 
            // felhasznalonev_textBox
            // 
            this.felhasznalonev_textBox.Location = new System.Drawing.Point(148, 56);
            this.felhasznalonev_textBox.Name = "felhasznalonev_textBox";
            this.felhasznalonev_textBox.Size = new System.Drawing.Size(100, 20);
            this.felhasznalonev_textBox.TabIndex = 3;
            this.felhasznalonev_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.felhasznalonev_textBox_KeyPress);
            // 
            // jelszo_textBox
            // 
            this.jelszo_textBox.Location = new System.Drawing.Point(148, 112);
            this.jelszo_textBox.Name = "jelszo_textBox";
            this.jelszo_textBox.PasswordChar = '*';
            this.jelszo_textBox.Size = new System.Drawing.Size(100, 20);
            this.jelszo_textBox.TabIndex = 4;
            this.jelszo_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jelszo_textBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Elfelejtettem a jelszavam!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jelszo_textBox);
            this.Controls.Add(this.felhasznalonev_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_button);
            this.Name = "Login";
            this.Text = "Login";
            this.Resize += new System.EventHandler(this.Login_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox felhasznalonev_textBox;
        private System.Windows.Forms.TextBox jelszo_textBox;
        public System.Windows.Forms.Button button1;


    }
}