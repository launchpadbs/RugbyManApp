using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class TeamStadiumUpdateModel
    {
        public int UserId { get; set; }
        public int OldStadiumId { get; set; }
        public int NewStadiumId { get; set; }
        public int TeamsId { get; set; }
    }
}
