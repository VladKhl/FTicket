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
    /// Логика взаимодействия для StoryPage.xaml
    /// </summary>
    public partial class StoryPage : Page
    {
        public int IDClient;
        public StoryPage(int idClient)
        {
            InitializeComponent();
            IDClient = idClient;
            List<StoryMatchModel> matchModels = new List<StoryMatchModel>();
            var stories = (from story in App.ticketsdbEntities.Story 
                          where story.idClient == IDClient select story).ToList();
            foreach (var story in stories)
            {
                StoryMatchModel matchModel = new StoryMatchModel();
                matchModel.Id = story.id;
                matchModel.Stage = (from mat in App.ticketsdbEntities.Match
                                    where mat.id == story.idMatch
                                    select mat.Stage).First().ToUpper();
                matchModel.Team = ByteArrayToImage((from mat in App.ticketsdbEntities.Match
                                                    where mat.id == story.idMatch
                                                    join team in App.ticketsdbEntities.Teams on mat.idTeam equals team.id
                                                    where mat.idTeam == team.id
                                                    join pho in App.ticketsdbEntities.Photo on team.idPhoto equals pho.id
                                                    where team.idPhoto == pho.id
                                                    select pho.Photo1).First());
                matchModel.Date = (from mat in App.ticketsdbEntities.Match
                                   where mat.id == story.idMatch
                                   select mat.DateAndTime).First().ToString().Substring(0, 10);
                matchModel.Time = (from mat in App.ticketsdbEntities.Match
                                   where mat.id == story.idMatch
                                   select mat.DateAndTime).First().ToString().Substring(11, 5);
                matchModel.Tourn = (from mat in App.ticketsdbEntities.Match
                                    where mat.id == story.idMatch
                                    join tour in App.ticketsdbEntities.Tournament on mat.idTour equals tour.id
                                    where tour.id == mat.idTour
                                    select tour.Name).First().ToUpper();
                matchModel.Sector = (int)story.Sector;
                matchModel.Row = (int)story.Row;
                matchModel.Place = (int)story.Place;
                matchModels.Add(matchModel);
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
        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.GoBack();
        }
    }
}
