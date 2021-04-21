using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlDemo
{
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public String Username
        {
            get { return this.txtUsername.Text; }
            set { this.txtPassword.Text = value; }
        }

        public String Password
        {
            get { return this.txtPassword.Text; }
            set { this.txtPassword.Text = value; }
        }
    }
}
