using FTicket.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FTicket.Model
{
    public class MatchModel
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public ImageSource Team { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Tourn { get; set; }
    }
}
