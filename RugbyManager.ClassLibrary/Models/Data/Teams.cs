using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models.Data
{
    class Teams
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Colour { get; set; }
        public int StadiumId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
