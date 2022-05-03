using FTicket.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для StadiumPage.xaml
    /// </summary>
    public partial class StadiumPage : Page
    {
        public MatchModel MatchModel;
        public int IDClient;
        public StadiumPage(MatchModel matchModel, int idClient)
        {
            InitializeComponent();
            IDClient = idClient;
            MatchModel = matchModel;
            int teamid = (from match in App.ticketsdbEntities.Match
                          where match.id == MatchModel.Id
                          select match.idTeam).First();
            sopimg.Source = ByteArrayToImage((from team in App.ticketsdbEntities.Teams
                                                join pho in App.ticketsdbEntities.Photo on team.idPhoto equals pho.id
                                                where team.id == teamid
                                                select pho.Photo1).First());
        }
        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream,
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SectorPage(Convert.ToInt32(((Button)sender).Content), IDClient, MatchModel.Id));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Brushes.Black;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Brushes.Transparent;
        }
    }
}
