﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class PlayerModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public decimal Height { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Position { get; set; }
        public int UserId { get; set; }
    }
}
