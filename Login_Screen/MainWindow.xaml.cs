using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Sender;
namespace Login_Screen
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    
    class Class
    {

    }
    public partial class LoginWindow : Window
    {
        string login;
        string password;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void GetVariables()
        {
            login=tbLogin.Text;
            password=tbPassword.Text;   
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            GetVariables();
          
        }
    }
}
