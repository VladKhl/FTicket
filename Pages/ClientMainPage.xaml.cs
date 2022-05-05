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
    /// Логика взаимодействия для ClientMainPage.xaml
    /// </summary>
    public partial class ClientMainPage : Page
    {
        public int IDClient;
        public ClientMainPage(int idClient)
        {
            InitializeComponent();
            IDClient = idClient;
            List<MatchModel> matchModels = new List<MatchModel>();
            var matchs = (from match in App.ticketsdbEntities.Match
                       select match).ToList();
            foreach (var match in matchs)
            {
                MatchModel matchModel = new MatchModel();
                matchModel.Id = match.id;
                matchModel.Stage = match.Stage;
                matchModel.Team = ByteArrayToImage((from team in App.ticketsdbEntities.Teams
                                   join pho in App.ticketsdbEntities.Photo on team.idPhoto equals pho.id where team.id == match.idTeam
                                   select pho.Photo1).First());
                matchModel.Date = match.DateAndTime.ToString().Substring(0, 10);
                matchModel.Time = match.DateAndTime.ToString().Substring(11, 5);
                matchModel.Tourn = (from mat in App.ticketsdbEntities.Match
                                     join tour in App.ticketsdbEntities.Tournament on mat.idTour equals tour.id
                                     where mat.idTour == match.idTour
                                     select tour.Name).First().ToUpper();
                if (match.DateAndTime > DateTime.Now)
                {
                    matchModels.Add(matchModel);
                }
            }
            matchlst.ItemsSource = matchModels;
        }
        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream,
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }

        private void matchlst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gg = matchlst.SelectedItem as MatchModel;
            NavigationService.Navigate(new StadiumPage(gg, IDClient));
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxExit = MessageBox.Show("Выйти из аккаунта?", "Выход", MessageBoxButton.YesNo);
            if (messageBoxExit == MessageBoxResult.Yes)
            NavigationService.Navigate(new StartPage());
        }

        private void storybtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoryPage(IDClient));
        }
    }
}
