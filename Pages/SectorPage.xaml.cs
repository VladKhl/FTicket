using FTicket.DB;
using FTicket.Windows;
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
    /// Логика взаимодействия для SectorPage.xaml
    /// </summary>
    public partial class SectorPage : Page
    {
        int numsec;
        int IDClient;
        int IDMatch;
        int marginleft = 30;
        int marginbottom = 35;
        int marginbottom2 = 357;
        int marginbottom3 = 518;
        public SectorPage(int numsec, int idClient, int idMatch)
        {
            InitializeComponent();
            this.numsec = numsec;
            IDClient = idClient;
            IDMatch = idMatch;
            for (int i = 1; i <= 40; i++)
            {
                Button btn = new Button();
                btn.Content = i.ToString();
                btn.Margin = new Thickness(marginleft, marginbottom3, 0, 0);
                btn.Height = 15;
                btn.Width = 15;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.FontSize = 9;
                btn.Background = new SolidColorBrush(Colors.White);
                btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                btn.CommandParameter = 1;
                btn.Click += btn_Click;
                int cnt = 0;
                var place = (from pla in App.ticketsdbEntities.Story select pla).ToList();
                foreach (var item in place)
                {
                    if (item.Place == i && item.idMatch == IDMatch && item.Row == 1 && item.Sector == numsec)
                    {
                        cnt++;
                    }
                }
                if (cnt > 0)
                {
                    btn.IsEnabled = false;
                }
                if (i == 20)
                {
                    marginleft = marginleft + 60;
                }
                else
                {
                    marginleft = marginleft + 20;
                }
                sectorgrd.Children.Add(btn);
            }
            for (int j = 22; j >= 9; j--)
            {
                marginleft = 30;
                for (int i = 1; i <= 40; i++)
                {
                    Button btn = new Button();
                    btn.Content = i.ToString();
                    btn.Margin = new Thickness(marginleft, marginbottom, 0, 0);
                    btn.Height = 15;
                    btn.Width = 15;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.FontSize = 9;
                    btn.Background = new SolidColorBrush(Colors.White);
                    btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    btn.CommandParameter = j;
                    btn.Click += btn_Click;
                    int cnt = 0;
                    var place = (from pla in App.ticketsdbEntities.Story select pla).ToList();
                    foreach (var item in place)
                    {
                        if (item.Place == i && item.idMatch == IDMatch && item.Row == j && item.Sector == numsec)
                        {
                            cnt++;
                        }
                    }
                    if (cnt > 0)
                    {
                        btn.IsEnabled = false;
                    }
                    if (i == 20)
                    {
                        marginleft = marginleft + 60;
                    }
                    else
                    {
                        marginleft = marginleft + 20;
                    }
                    sectorgrd.Children.Add(btn);
                }
                marginbottom = marginbottom + 23;
            }
            for (int j = 8; j >= 2; j--)
            {
                marginleft = 30;
                for (int i = 1; i <= 34; i++)
                {
                    Button btn = new Button();
                    btn.Content = i.ToString();
                    btn.Margin = new Thickness(marginleft, marginbottom2, 0, 0);
                    btn.Height = 15;
                    btn.Width = 15;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.FontSize = 9;
                    btn.Background = new SolidColorBrush(Colors.White);
                    btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    btn.CommandParameter = j;
                    btn.Click += btn_Click;
                    int cnt = 0;
                    var place = (from pla in App.ticketsdbEntities.Story select pla).ToList();
                    foreach (var item in place)
                    {
                        if (item.Place == i && item.idMatch == IDMatch && item.Row == j && item.Sector == numsec)
                        { 
                            cnt++;
                        }
                    }
                    if (cnt > 0)
                    {
                        btn.IsEnabled = false;
                    }
                    if (i == 17)
                    {
                        marginleft = marginleft + 180;
                    }
                    else
                    {
                        marginleft = marginleft + 20;
                    }
                    sectorgrd.Children.Add(btn);
                }
                marginbottom2 = marginbottom2 + 23;
            }
        }
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            var place = (from pla in App.ticketsdbEntities.Story select pla).ToList();
            foreach (var item in place)
            {
                if (item.idClient == IDClient && item.idMatch == IDMatch)
                {
                    cnt++;
                }
            }
            if (cnt < 2)
            {
                SaleWin saleWin = new SaleWin(numsec, Convert.ToInt32(((Button)sender).CommandParameter), Convert.ToInt32(((Button)sender).Content), IDMatch, IDClient);
                ((Button)sender).IsEnabled = false;
                saleWin.Show();
            }
            else
            {
                MessageBox.Show("Вы не можете приобрести больше двух билетов на один матч");
            }
        }
    }
}
