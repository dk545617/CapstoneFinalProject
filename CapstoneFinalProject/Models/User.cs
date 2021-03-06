﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneFinalProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "You must enter your first name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "First name must be valid")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter your last name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Last name must be valid")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter your email")]
        [RegularExpression(@"^[\w\.\-]+@[\w\.\-]+\.[a-zA-Z]+$", ErrorMessage = "Email must be valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must enter your phone")]
        
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
    }
}
