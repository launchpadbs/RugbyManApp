using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models.Data
{
    class Players
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Height { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
    }
}
