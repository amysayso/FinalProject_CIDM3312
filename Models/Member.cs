using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Member : Person
    {
        [Display(Name = "Major")] 
        public string Major {get; set;}
  
    }
}