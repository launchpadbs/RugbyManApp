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
        public int OldTeamId { get; set; }
        [Required]
        public int NewTeamId { get; set; }
        [Required]
        public int PlayerId { get; set; }
    }
}
