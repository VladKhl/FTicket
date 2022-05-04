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
            var matchs = (from story in App.ticketsdbEntities.Story 
                          join match in App.ticketsdbEntities.Match on story.idMatch equals match.id where story.idMatch == match.id
                          where story.idClient == IDClient select story).ToList();
            foreach (var match in matchs)
            {
                //StoryMatchModel matchModel = new StoryMatchModel();
                //matchModel.Id = match.id;
                //matchModel.Stage = (from story in App.ticketsdbEntities.Story
                //                   join mat in App.ticketsdbEntities.Match on story.idMatch equals match.id
                //                   where story.idMatch == match.id
                //                   where story.idClient == IDClient
                //                   select mat.Stage).First();
                //matchModel.Team = ByteArrayToImage((  from story in App.ticketsdbEntities.Story
                //                                      join mat in App.ticketsdbEntities.Match on story.idMatch equals match.id
                //                                      where story.idMatch == match.id
                //                                      join team in App.ticketsdbEntities.Teams on mat.idTeam equals team.id
                //                                      where mat.idTeam == team.id
                //                                      join pho in App.ticketsdbEntities.Photo on team.idPhoto equals pho.id
                //                                      where team.id == match.idTeam
                //                                      select pho.Photo1).First());
                //matchModel.Date = match.DateAndTime.ToString().Substring(0, 10);
                //matchModel.Time = match.DateAndTime.ToString().Substring(11, 5);
                //matchModel.Tourn = (from mat in App.ticketsdbEntities.Match
                //                    join tour in App.ticketsdbEntities.Tournament on mat.idTour equals tour.id
                //                    where mat.idTour == match.idTour
                //                    select tour.Name).First().ToUpper();
                //matchModel.Sector = (int)match.Sector;
                //matchModel.Row = (int)match.Row;
                //matchModel.Place = (int)match.Place;
                //matchModels.Add(matchModel);
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
