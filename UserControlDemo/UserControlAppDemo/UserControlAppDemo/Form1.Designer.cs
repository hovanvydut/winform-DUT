
namespace UserControlAppDemo
{
    partial class Form1
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
            this.loginForm1 = new UserControlDemo.LoginForm();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginForm1
            // 
            this.loginForm1.Location = new System.Drawing.Point(28, 22);
            this.loginForm1.Name = "loginForm1";
            this.loginForm1.Password = "";
            this.loginForm1.Size = new System.Drawing.Size(496, 170);
            this.loginForm1.TabIndex = 0;
            this.loginForm1.Username = "";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(248, 229);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 283);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.loginForm1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlDemo.LoginForm loginForm1;
        private System.Windows.Forms.Button btnLogin;
    }
}

