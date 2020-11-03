using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class TeamModel
    {
        public int TeamsId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Colour { get; set; }
        public int StadiumId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
