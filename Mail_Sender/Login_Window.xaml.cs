using System;
using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;
using System.Windows;

using Sender_Screen;
namespace Mail_Sender
{
    public partial class Login_Window : Window
    {
        
        string login;
        string password;
        public Login_Window()
        {
            InitializeComponent();
        }
        private void GetVariables()
        {
            login = tbLogin.Text;
            
            password = tbPassword.Text;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            GetVariables();
            if (Validate_Email_Adress(login))
            {
                if (Valide_Password(password))
                {
                    MailWindow send = new MailWindow(login, password);
                    send.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
            else
            {
                MessageBox.Show("Invalid email address");
            }
        }
        private bool Validate_Email_Adress(string mail)
        {
            if(string.IsNullOrEmpty(mail))
                return false;//empty field
            try
            {
                MailAddress address = new MailAddress(mail);
                return true;//valid
            }
            catch (FormatException)
            {
                return false;//invalid
            }

        }
        private bool Valide_Password(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            if(password.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
