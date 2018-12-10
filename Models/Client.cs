using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Client : Person
    {
        [Display(Name = "Company Name")]
        public string CompanyName {get; set;}


    }
}