﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model.ViewModel
{
    public class LoginView
    {
        [Required(ErrorMessage = "Username  is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password  is Required.")]
        public string Password { get; set; }
      
    }
}
