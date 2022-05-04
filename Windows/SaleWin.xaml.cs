using FTicket.DB;
using FTicket.Pages;
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
using System.Windows.Shapes;

namespace FTicket.Windows
{
    /// <summary>
    /// Логика взаимодействия для SaleWin.xaml
    /// </summary>
    public partial class SaleWin : Window
    {
        int numsec;
        int IDClient;
        int IDMatch;
        int pRow;
        int pPlace;
        bool buycheck = false;

        public SaleWin(int numsec, int row, int place, int idmatch, int idclient)
        {
            InitializeComponent();
            this.numsec = numsec;
            IDClient = idclient;
            IDMatch = idmatch;
            pRow = row;
            pPlace = place;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
            Story story = new Story()
            {
                idMatch = IDMatch,
                Sector = numsec,
                Row = pRow,
                Place = pPlace,
                idClient = IDClient
            };
            App.ticketsdbEntities.Story.Add(story);
            App.ticketsdbEntities.SaveChanges();

        }

        private void timerTick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buybtn_Click(object sender, RoutedEventArgs e)
        {
            buycheck = true;
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (buycheck == false)
            {
                var gg = (from sto in App.ticketsdbEntities.Story 
                          where sto.idMatch == IDMatch 
                          where sto.Sector == numsec  
                          where sto.Row == pRow
                          where sto.Place == pPlace
                          where sto.idClient == IDClient
                          select sto).First();
                App.ticketsdbEntities.Story.Remove(gg);
                App.ticketsdbEntities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Успешно");
            }
        }
    }
}
