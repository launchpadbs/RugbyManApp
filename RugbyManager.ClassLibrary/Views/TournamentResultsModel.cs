using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Views
{
    public class TournamentResultsModel
    {
        public Guid TournamentDrawGuid { get; set; }
        public int LeagueId { get; set; }
        public int TeamId { get; set; }
        public int ResultPoints { get; set; }
    }
}
