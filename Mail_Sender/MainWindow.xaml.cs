using System.Windows;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Win32;
using Mail_Sender;
namespace Sender_Screen
{
    public partial class MailWindow : Window
    {
        MimeMessage message;
        OpenFileDialog dialog;
        MessageImportance importance;
        string user;
        string password;
        public MailWindow(string login, string password)
        {
            importance = MessageImportance.Normal;
            message = new MimeMessage();    
            dialog = new OpenFileDialog();
            InitializeComponent();
            this.user = login;
            this.password = password;   
        }

        
        private MimeMessage Make_Message()
        {
            message.From.Add(new MailboxAddress(user, user));
            message.To.Add(new MailboxAddress("User", tbSendTo.Text));
            message.Subject = tbTheme.Text;
            message.Importance = importance;
            message.Body = Make_Message_Body().ToMessageBody();
            return message;
        }

        private BodyBuilder Make_Message_Body()
        {
                BodyBuilder builder = new BodyBuilder();
            if (dialog.FileNames == null)
            {
                builder.TextBody = $@"{tbMessage.Text}";

                return builder;
            }
            else
            {
                foreach (var item in dialog.FileNames)
                {
                builder.Attachments.Add(item);
                }
                builder.TextBody = $@"{tbMessage.Text}";

                return builder;
            }
        }
        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                try
                {
                client.Authenticate(user, password);
                    client.Send(Make_Message());
                    MessageBox.Show("Letter sent succesfully", "Succes");

                }
                catch (System.Exception)
                {
                    MessageBox.Show("Failed to send (check your password or resivers email)", "Fail");
                }
            }
        }



        private void Attach_File_Button_Click(object sender, RoutedEventArgs e)
        {
            dialog.Multiselect = true;

            dialog.ShowDialog();

        }

        private void Set_Priority_Button_Click(object sender, RoutedEventArgs e)
        {
            importance = MessageImportance.High;
        }
    }
}
