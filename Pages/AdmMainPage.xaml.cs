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
    /// Логика взаимодействия для AdmMainPage.xaml
    /// </summary>
    public partial class AdmMainPage : Page
    {
        public AdmMainPage()
        {
            InitializeComponent();
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            datematch.DisplayDateStart = tomorrow;
            var tem = App.ticketsdbEntities.Teams.ToList();
            teamcb.ItemsSource = tem;
            teamcb.DisplayMemberPath = "Name";
            var tor = App.ticketsdbEntities.Tournament.ToList();
            tourn.ItemsSource = tor;
            tourn.DisplayMemberPath = "Name";
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxExit = MessageBox.Show("Выйти из админ-аккаунта?", "Выход", MessageBoxButton.YesNo);
            if (messageBoxExit == MessageBoxResult.Yes)
                NavigationService.Navigate(new StartPage());
        }

        private void addabbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cnt= 0;
                var check = App.ticketsdbEntities.Aboniment.ToList();
                foreach (var item in check)
                {
                    if (item.Number == abtxt.Text)
                    {
                        cnt++;
                    }
                }
                if (cnt > 0)
                {
                    MessageBox.Show("Абонемент с таким номером уже существует");
                }
                else
                {
                    Aboniment aboniment = new Aboniment()
                    {
                        Number = abtxt.Text,
                        Used = false
                    };
                    App.ticketsdbEntities.Aboniment.Add(aboniment);
                    App.ticketsdbEntities.SaveChanges();
                    MessageBox.Show("Абонемент успешно добавлен");
                    abtxt.Text = "";
                }
            }
            catch { MessageBox.Show("Введите корректные данные"); }
        }

        private void addmatchbtn_Click(object sender, RoutedEventArgs e)
        {
            var tea = teamcb.SelectedItem as Teams;
            var tou = tourn.SelectedItem as Tournament;
            try
            {
                int cnt = 0;
                var check = App.ticketsdbEntities.Match.ToList();
                foreach (var item in check)
                {
                    if (item.DateAndTime.ToString().Substring(0, 10) == datematch.Text.Substring(0, 10))
                    {
                        cnt++;
                    }
                }
                if (cnt > 0 || datematch.SelectedDate <= datematch.DisplayDateStart)
                {
                    MessageBox.Show("Некорректная дата");
                }
                else
                {
                    if ((string.IsNullOrWhiteSpace(stagetxt.Text) || string.IsNullOrWhiteSpace(timamatch.Text)) || string.IsNullOrWhiteSpace(teamcb.Text) || string.IsNullOrWhiteSpace(tourn.Text))
                    { MessageBox.Show("Введите все данные"); }
                    else
                    {
                        Match match = new Match()
                        {
                            Stage = stagetxt.Text,
                            idTeam = tea.id,
                            idTour = tou.id,
                            DateAndTime = Convert.ToDateTime($"{datematch.Text} {timamatch.Text}")
                        };
                        App.ticketsdbEntities.Match.Add(match);
                        App.ticketsdbEntities.SaveChanges();
                        MessageBox.Show("Матч успешно добавлен");
                        stagetxt.Text = "";
                        teamcb.Text = "";
                        tourn.Text = "";
                        datematch.Text = "";
                        timamatch.Text = "";
                    }
                }
            }
            catch { MessageBox.Show("Введите корректные данные"); }
        }
    }
}
