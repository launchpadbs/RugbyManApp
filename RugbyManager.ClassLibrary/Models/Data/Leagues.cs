using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models.Data
{
    class Leagues
    {
        public int LeagueId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }
    }
}
