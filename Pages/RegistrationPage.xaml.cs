using FTicket.DB;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
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

        private void surname_MouseEnter(object sender, MouseEventArgs e)
        {
            if (surname.Text == "ФАМИЛИЯ")
                surname.Clear();
        }

        private void name_MouseEnter(object sender, MouseEventArgs e)
        {
            if (name.Text == "ИМЯ")
                name.Clear();
        }

        private void middlename_MouseEnter(object sender, MouseEventArgs e)
        {
            if (middlename.Text == "ОТЧЕСТВО")
                middlename.Clear();
        }

        private void aboniment_MouseEnter(object sender, MouseEventArgs e)
        {
            if (aboniment.Text == "АБОНЕМЕНТ")
                aboniment.Clear();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login.Text) || (login.Text == "ЛОГИН") 
                || string.IsNullOrWhiteSpace(surname.Text) || (surname.Text == "ФАМИЛИЯ")
                || string.IsNullOrWhiteSpace(password.Text) || (password.Text == "ПАРОЛЬ")
                || string.IsNullOrWhiteSpace(name.Text) || (name.Text == "ИМЯ")
                || string.IsNullOrWhiteSpace(middlename.Text) || (middlename.Text == "ОТЧЕСТВО")
                || string.IsNullOrWhiteSpace(aboniment.Text) || (aboniment.Text == "АБОНЕМЕНТ"))
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                int checklog = 0;
                int checkab = 0;
                int idab = 0;
                var log = (from auf in App.ticketsdbEntities.Client
                           where auf.Login == login.Text.ToLower()
                           select auf.Login).ToList();
                foreach (var logi in log)
                {
                    if (logi == login.Text.ToLower().Trim())
                    {
                        MessageBox.Show("Аккаунт с такими данными уже существует");
                        checklog++;
                    }
                }
                if (checklog == 0)
                {
                    var ab = (from abo in App.ticketsdbEntities.Aboniment
                               select abo).ToList();
                    foreach (var abon in ab)
                    {
                        if (abon.Number == aboniment.Text.ToLower().Trim())
                        {
                            checkab++;
                            if (abon.Used == true)
                            {
                                MessageBox.Show("Абонемент уже использован");
                            }
                            else
                            {
                                idab = abon.id;
                                try
                                {
                                    Client acc = new Client
                                    {
                                        Name = name.Text.ToLower(),
                                        Surname = surname.Text.ToLower(),
                                        Middlename = middlename.Text.ToLower(),
                                        idAb = idab,
                                        idRole = 1402,
                                        Login = login.Text,
                                        Password = password.Text
                                    };
                                    App.ticketsdbEntities.Client.Add(acc);
                                    App.ticketsdbEntities.SaveChanges();
                                    var abus = (from abo in App.ticketsdbEntities.Aboniment
                                                where abo.id == idab
                                                select abo).First();
                                    abus.Used = true;
                                    App.ticketsdbEntities.SaveChanges();
                                    MessageBox.Show("Аккаунт зарегестрирован");
                                    NavigationService.GoBack();
                                }
                                catch
                                {
                                    MessageBox.Show("Данные введены не корректно");
                                }
                            }
                        }
                    }
                    if (checkab == 0)
                    {
                        MessageBox.Show("Номер абонемента введен неверно");
                    }
                }
            }
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }
    }
}
