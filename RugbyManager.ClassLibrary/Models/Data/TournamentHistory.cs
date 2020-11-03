using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models.Data
{
    class TournamentHistory
    {
        public Guid TournamentDrawGuid { get; set; }
        public int LeagueId { get; set; }
        public int TeamIdA { get; set; }
        public int TeamIdB { get; set; }
        public int ResultA { get; set; }
        public int ResultB { get; set; }
        public string MatchTime { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
