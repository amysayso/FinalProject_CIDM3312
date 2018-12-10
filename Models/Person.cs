using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Person
    {
        [Key]
        public int ID {get; set;}

        [Display(Name = "First Name")]                
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]                
        public string LastName { get; set; }

        [Display(Name = "Email Address")]                
        public string Email{ get; set; }

        [Display(Name = "Phone Number")]                
        public string Phone{ get; set; }
        public ICollection<ProjectList> Projects {get; set;}

        public override string ToString(){
            return $"First Name: {this.FirstName} Last Name: {this.LastName}";
    }
}
}