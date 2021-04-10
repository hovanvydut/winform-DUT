using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityPanel
{
    public partial class Form1 : Form
    {
        private string password = "1234";
        private string pwdUserInput = "";

        public Form1()
        {
            InitializeComponent();
            loadFile();
            focusButtonEnter();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string txt = button.Text;
            addStringToPwdUserInput(txt);
            focusButtonEnter();
        }

        private void addStringToPwdUserInput(String txt)
        {
            if (ValidLengthPasswordToInput(this.pwdUserInput, 4))
            {
                this.pwdUserInput += txt;
                ShowPwd();
            }
        }

        private void ShowPwd()
        {
            this.input.Text = pwdUserInput;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            resetPwdUserInput();
        }

        private bool ValidLengthPasswordToInput(string txt, int maxLength)
        {
            return txt.Length < maxLength;
        }

        private void resetPwdUserInput()
        {
            this.pwdUserInput = "";
            input.Text = pwdUserInput;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            matchPassword(this.pwdUserInput, this.password);
        }

        private void matchPassword(string userPwd, string systemPwd)
        {
            if (userPwd.Equals(systemPwd))
            {
                insertIntoListLog(DateTime.Now.ToString() + "                         Login successfully");
            }
            else
            {
                insertIntoListLog(DateTime.Now.ToString() + "                         Login fail!");
            }

            this.resetPwdUserInput();
        }

        private void insertIntoListLog(string txt)
        {
            this.list_log.Items.Add(txt);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                matchPassword(this.pwdUserInput, this.password);
                return;
            }

            if (e.KeyCode == Keys.Back)
            {
                matchPassword(this.pwdUserInput, this.password);
                return;
            }

            int c = e.KeyValue;
            if (c >= 48 && c <= 57)
                addStringToPwdUserInput((c-48).ToString());

            // disable focus when click a button
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter writer = new StreamWriter(@"D:\Study\HK4\C#\code\winform\SecurityPanel\SecurityPanel\bin\Debug\102190200.txt");
            
            for (int i = 0; i < this.list_log.Items.Count; i++)
            {
                writer.WriteLine(this.list_log.Items[i].ToString());
            }

            writer.Close();
        }

        private void loadFile()
        {
            //FileInfo sourceFIle = new FileInfo(@"D:\Study\HK4\C#\code\winform\SecurityPanel\SecurityPanel\bin\Debug\102190200.txt");
            StreamReader reader = new StreamReader(@"D:\Study\HK4\C#\code\winform\SecurityPanel\SecurityPanel\bin\Debug\102190200.txt");

            string txt;
            do
            {
                txt = reader.ReadLine();

                if (txt != null)
                    insertIntoListLog(txt);
            } while (txt != null);

            reader.Close();
        }

        private void focusButtonEnter()
        {
            this.buttonEnter.Focus();
        }

    }
}
