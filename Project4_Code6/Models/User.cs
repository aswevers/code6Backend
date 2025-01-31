﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4_Code6.Models
{
    public class User{
        public int UserID{ get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }
        
        [NotMapped] 
        public string Token { get; set; }
    }
}
