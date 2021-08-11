﻿using EmployeeManagment.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class RegisterViewModel{

        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse" ,controller: "Account")]
        [ValideEmailDomain(allowedDomain:"ubt-uni.net",ErrorMessage ="Email domain must be ubt-uni.net ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm password")]
        [Compare("Password",ErrorMessage="Does Not Match")]
        public string ConfirmPassword { get; set; }


        public string City { get; set; }

    }
}
