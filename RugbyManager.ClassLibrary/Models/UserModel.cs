using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyManager.ClassLibrary.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string AccountId { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }
    }
}
