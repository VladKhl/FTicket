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

namespace FTicket.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void Window_load(object sender, RoutedEventArgs e)
        {
            login.Text = "ЛОГИН";
            password.Text = "ПАРОЛЬ";
        }
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var log = (from auf in App.ticketsdbEntities.Client where auf.Login == login.Text.ToLower() where auf.Password == password.Text.ToLower() select auf).First();
                if (log.idRole == 1401)
                {
                    MessageBox.Show("Вы вошли в админ-аккаунт");
                    NavigationService.Navigate(new AdmMainPage());
                }
                else
                {
                    NavigationService.Navigate(new ClientMainPage(log.id));
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void login_MouseEnter(object sender, MouseEventArgs e)
        {
            if (login.Text == "ЛОГИН")
                login.Clear();
        }

        private void password_MouseEnter(object sender, MouseEventArgs e)
        {
            if (password.Text == "ПАРОЛЬ")
                password.Clear();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
