using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class PlayerTeamUpdateModel
    {
        [Required]
        public int UserId { get; set; }
        public int OldTeamsId { get; set; }
        [Required]
        public int NewTeamsId { get; set; }
        [Required]
        public int PlayersId { get; set; }
    }
}
