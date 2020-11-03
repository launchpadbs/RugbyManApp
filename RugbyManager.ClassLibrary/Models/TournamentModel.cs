using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class TournamentModel
    {
        public Guid TournamentDrawGuid { get; set; }
        public int LeaguesId { get; set; }
        public int TeamsId { get; set; }
        public int Draw { get; set; }
        public int Round { get; set; }
        public int ResultPoints { get; set; }
        public bool Active { get; set; }
    }
}
